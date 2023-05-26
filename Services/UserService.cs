using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartSence.Database.Entities;
using SmartSence.DTO;
using SmartSence.DTO.Identity;
using SmartSence.Extensions;
using SmartSence.Migrations;
using SmartSence.Wrappers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IResult = SmartSence.Wrappers.IResult;

namespace SmartSence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<UserRole> _roleManager;
        //private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        //private readonly AppConfiguration _appConfig;
        private readonly SignInManager<User> _signInManager;
        //private readonly GoogleConfiguration _googleConfig;
        public int AuthenticatedUserID { get; }
        public List<KeyValuePair<string, string>> AuthenticatedUserClaims { get; set; }
        //private readonly IMapper _mapper;
       


        public UserService(
            UserManager<User> userManager,
            IMapper mapper,
            RoleManager<UserRole> roleManager,
            //IMailService mailService,
            // IOptions<AppConfiguration> appConfig,
            SignInManager<User> signInManager,
            IHttpContextAccessor httpContextAccessor
           )
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            //_mailService = mailService;
            // _appConfig = appConfig.Value;
            _signInManager = signInManager;
            AuthenticatedUserID = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            AuthenticatedUserClaims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
          
            //_googleConfig = googleConfig;
        }

        public async Task<UserDto> GetCurrentUserAsync()
        {
            var user = await _userManager.Users.Where(u => u.Id == AuthenticatedUserID).FirstOrDefaultAsync();
            var result = _mapper.Map<UserDto>(user);
            result.Role = _userManager.GetRolesAsync(user).Result.FirstOrDefault();
           // result.UserPermissions = AuthenticatedUserClaims.Where(c => c.Key == "Permission").Select(c => c.Value).ToList();
            return result;
        }

        public async Task<PaginatedResult<UserDto>> GetAllAsync(int pageNumber, int pageSize, string sortField, string sortOrder, string searchText, long? orgId)
        {

            var filteredUsers = orgId.HasValue ? _userManager.Users.Where(p => p.OrganizationId == orgId.Value) : _userManager.Users;
            filteredUsers =  searchText.IsNullOrEmpty()
                ? filteredUsers
                : filteredUsers.Where(p => p.UserName.Contains(searchText));

            var sortedUsers = filteredUsers.OrderBy($"{sortField} {sortOrder}");
            var userResponses = sortedUsers.Select(l => _mapper.Map<UserDto>(l)).ToPaginatedListAsync(pageNumber, pageSize);

            //foreach (var mappedUser in userResponses.Result.Data)
            //{
            //    var user = sortedUsers.First(u => u.Id.Equals(mappedUser.Id));
            //    var roles = await _userManager.GetRolesAsync(user);
            //    mappedUser.Roles = roles.ToList();
            //}

            return await userResponses;

        }


        public async Task<IResult<List<UserDto>>> GetAll(long? orgId)
        {
            var filteredUsers = orgId.HasValue ? _userManager.Users.Where(p => p.OrganizationId == orgId.Value).ToList() : _userManager.Users.ToList();
            return await Result<List<UserDto>>.SuccessAsync(_mapper.Map<List<UserDto>>(filteredUsers));

        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RegisterAsync(RegisterModel request, string origin)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.Username);
            if (userWithSameUserName != null)
                return await Result.FailAsync("User Not Found.");
            // return string.Format("Username {0} is already taken.", request.UserName);

            var user = new User
            {
                Email = request.Email,
                UserName = request.Username.IsNullOrEmpty() ? request.Email : request.Username,
                IsActive = true,
               
            };

            //if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            //{
            //    var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
            //    if (userWithSamePhoneNumber != null)
            //    {
            //        return await Result.FailAsync(string.Format("Phone number {0} is already registered.", request.PhoneNumber));
            //    }
            //}

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null)
                return await Result.FailAsync($"Email {request.Email} is already registered.");


            // return string.Format("Email {0} is already registered.", request.Email);

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, request.Role);
                //if (!request.AutoConfirmEmail)
                //{
                //    var verificationUri = await SendVerificationEmail(user, origin);
                //    var mailRequest = new MailRequest
                //    {
                //        To = user.Email,
                //        Body = $"Please confirm your account by <a href='{verificationUri}'>clicking here</a>.",
                //        Subject = "Confirm Registration"
                //    };
                //    _mailService.SendAsync(mailRequest);
                //    return await Result<string>.SuccessAsync(user.Id, string.Format("User {0} Registered. Please check your Mailbox to verify!", user.UserName));
                //}

                return await Result.SuccessAsync($"User {user.UserName} registered."); ;
            }
            return await Result.FailAsync(string.Join(',', result.Errors.Select(a => a.Description.ToString())));
            // return string.Join(',', result.Errors.Select(a => a.Description.ToString()));



        }

        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest request)
        {
            if (request.Password == request.NewPassword)
                return await Result.FailAsync("New password cannot be equal to old password.");


            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return await Result.FailAsync("User Not Found");

            var identityResult = await _userManager.ChangePasswordAsync(
                user,
                request.Password,
                request.NewPassword);
            var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
            return identityResult.Succeeded ?
                await Result.SuccessAsync("Password Updated Successfully") :
                await Result.FailAsync(string.Join(", ", identityResult.Errors.Select(e => e.Description.ToString()).ToList()));
        }

        public async Task<Result<TokenResponse>> Login(LoginModel model)
        {
            User user = null;
            if (model.Email.IsNotNullOrEmpty())
                user = await _userManager.FindByEmailAsync(model.Email);
            if (model.Username.IsNotNullOrEmpty())
                user = await _userManager.FindByNameAsync(model.Username);

            if (user == null)
                return await Result<TokenResponse>.FailAsync("User Not Found.");

            if (!user.IsActive)
                return await Result<TokenResponse>.FailAsync("User Not Active. Please contact the administrator.");

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
                return await Result<TokenResponse>.FailAsync("Invalid Credentials.");


            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
                                                {
                                                new Claim(ClaimTypes.Name, user.UserName),
                                                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                                };
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!")); //_jwtSettings.Key
            var token = new JwtSecurityToken(
            issuer: "JobHunt.Api", //_jwtSettings.Issuer,
            audience: "JobHunt.Api", // _jwtSettings.Audience,
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            TokenResponse response = new() { Token = new JwtSecurityTokenHandler().WriteToken(token), UserId = user.Id, Role = userRoles.FirstOrDefault() };
            return await Result<TokenResponse>.SuccessAsync(response);
        }

        public async Task<Result<DashboardSummary>> GetUserSummary(DashboardFilter filter)
        {
            var summary = new DashboardSummary
            {
                EntityType = "User",
                OnlineEntites = 13,
                OfflineEntities = 2
            };

            return await Result<DashboardSummary>.SuccessAsync(summary);
        }

        public async Task<Result<UserDto>> GetUserById(long userId)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var result = _mapper.Map<UserDto>(user);
            result.Role = _userManager.GetRolesAsync(user).Result.ToList().FirstOrDefault();
            //result.UserPermissions = AuthenticatedUserClaims.Where(c => c.Key == "Permission").Select(c => c.Value).ToList();
            return await Result<UserDto>.SuccessAsync(result);
        }

        public async Task<IResult> UpdateUserAsync(UserDto request)
        {
            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Id != request.Id);
                if (userWithSamePhoneNumber != null)
                    return await Result.FailAsync(string.Format("Phone number {0} is already used.",
                        request.PhoneNumber));
            }

            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null)
            {
                return await Result.FailAsync("User Not Found.");
            }
            //user.UserName = request.UserName;
            user.PhoneNumber = request.PhoneNumber;
            //user.Email = request.Email;
            //user.FirstName = request.FirstName;
            //user.LastName = request.LastName;

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (request.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
            }
            var identityResult = await _userManager.UpdateAsync(user);
            var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
            await _signInManager.RefreshSignInAsync(user);


            if (identityResult.Succeeded)
            {
                await UpdateRoleAsync(request.Id, request.Role);
                return await Result.SuccessAsync("Profile updated successfully!");
            }

            return await Result.FailAsync(errors);
        }

        public async Task<IResult> UpdateRoleAsync(long userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            var roles = await _userManager.GetRolesAsync(user);

            //var currentUser = await _userManager.FindByIdAsync(_currentUserService.UserId);
            //if (!await _userManager.IsInRoleAsync(currentUser, RoleConstants.AdministratorRole))
            //{
            //    var userHasAdministratorRole = roles.Any(x => x == RoleConstants.AdministratorRole);
            //    if (role.Equals(RoleConstants.AdministratorRole) && !userHasAdministratorRole || !role.Equals(RoleConstants.AdministratorRole) && userHasAdministratorRole)
            //        return await Result.FailAsync("Not Allowed to add or delete Administrator Role if you have not this role.");
            //}

            await _userManager.RemoveFromRolesAsync(user, roles);
            await _userManager.AddToRoleAsync(user, role);
            return await Result.SuccessAsync("Role Updated");
        }


        public async Task<IResult<long>> CreateUser(UserDto request)
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null && !userWithSameUserName.IsDeleted)
                return await Result<long>.FailAsync(string.Format("Username {0} is already taken.", request.UserName));

            var user = new User
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = request.PasswordHash,
            };

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
                if (userWithSamePhoneNumber != null && !userWithSamePhoneNumber.IsDeleted)
                    return await Result<long>.FailAsync(string.Format("Phone number {0} is already registered.", request.PhoneNumber));
            }

            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail != null && !userWithSameEmail.IsDeleted)
                return await Result<long>.FailAsync(string.Format("Email {0} is already registered.", request.Email));

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                return await Result<long>.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());

            await _userManager.AddToRoleAsync(user, request.Role);
            //var passwordSetUri = await GetPasswordSetToken(user, request.IsRequestFromClientApp);
            //var mailRequest = new MailRequest
            //{
            //    To = user.Email,
            //    Body = $"Please confirm your account and set password by <a href='{passwordSetUri}'>clicking here</a>.",
            //    Subject = "Confirm Registration and Set Password"
            //};
            //_mailService.SendAsync(mailRequest);
            return await Result<long>.SuccessAsync(user.Id, string.Format("User {0} Registered. Please check Mailbox to verify!", user.UserName));

        }

        //private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        //{
        //    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //    var route = "api/identity/user/confirm-email/";
        //    var endpointUri = new Uri(string.Concat($"{origin}/", route));
        //    var verificationUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "userId", user.Id);
        //    verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
        //    return verificationUri;
        //}

        //private async Task<string> GetPasswordSetToken(ApplicationUser user, bool IsClientApp)
        //{
        //    var passwordReset = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    var code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(passwordReset));
        //    var passwordSetEndpointUri = new Uri(string.Concat($"{_appConfig.FrontEndBaseUrl}", IsClientApp? _appConfig.FrontEndStaffSetPasswordUrl: _appConfig.FrontEndClientSetPasswordUrl));
        //    var passwordResetURL = HtmlEncoder.Default.Encode(passwordSetEndpointUri.AbsoluteUri + code);
        //    return passwordResetURL;
        //}

        //public async Task<IResult<UserResponse>> GetAsync(string userId)
        //{
        //    var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        //    var result = _mapper.Map<UserResponse>(user);
        //    var roles = await _userManager.GetRolesAsync(user);
        //    result.Roles = roles.ToList();
        //    return await Result<UserResponse>.SuccessAsync(result);
        //}

        //public async Task<ApplicationUser> GetApplicationUser(string userId) => await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

        //public async Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request)
        //{
        //    var user = await _userManager.Users.Where(u => u.Id == request.UserId).FirstOrDefaultAsync();
        //    if (user == null) return await Result.SuccessAsync();
        //    user.IsActive = request.ActivateUser;
        //    var identityResult = await _userManager.UpdateAsync(user);
        //    return await Result.SuccessAsync();
        //}

        //public async Task<IResult<UserRolesResponse>> GetRolesAsync(string userId)
        //{
        //    var viewModel = new List<UserRoleModel>();
        //    var user = await _userManager.FindByIdAsync(userId);
        //    var roles = await _roleManager.Roles.ToListAsync();
        //    foreach (var role in roles)
        //    {
        //        var userRolesViewModel = new UserRoleModel
        //        {
        //            RoleName = role.Name,
        //            RoleDescription = role.Description
        //        };
        //        if (await _userManager.IsInRoleAsync(user, role.Name))
        //        {
        //            userRolesViewModel.Selected = true;
        //        }
        //        else
        //        {
        //            userRolesViewModel.Selected = false;
        //        }
        //        viewModel.Add(userRolesViewModel);
        //    }
        //    var result = new UserRolesResponse { UserRoles = viewModel };
        //    return await Result<UserRolesResponse>.SuccessAsync(result);
        //}

        //public async Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        //{
        //    var user = await _userManager.FindByIdAsync(request.UserId);
        //    if (user.Email == "mukesh@blazorhero.com")
        //    {
        //        return await Result.FailAsync("Not Allowed.");
        //    }

        //    var roles = await _userManager.GetRolesAsync(user);
        //    var selectedRoles = request.UserRoles.Where(x => x.Selected).ToList();

        //    var currentUser = await _userManager.FindByIdAsync(_currentUserService.UserId);
        //    if (!await _userManager.IsInRoleAsync(currentUser, RoleConstants.AdministratorRole))
        //    {
        //        var tryToAddAdministratorRole = selectedRoles
        //            .Any(x => x.RoleName == RoleConstants.AdministratorRole);
        //        var userHasAdministratorRole = roles.Any(x => x == RoleConstants.AdministratorRole);
        //        if (tryToAddAdministratorRole && !userHasAdministratorRole || !tryToAddAdministratorRole && userHasAdministratorRole)
        //        {
        //            return await Result.FailAsync("Not Allowed to add or delete Administrator Role if you have not this role.");
        //        }
        //    }

        //    var result = await _userManager.RemoveFromRolesAsync(user, roles);
        //    result = await _userManager.AddToRolesAsync(user, selectedRoles.Select(y => y.RoleName));
        //    return await Result.SuccessAsync("Roles Updated");
        //}


        

        //public async Task<IResult<string>> ConfirmEmailAsync(string userId, string code)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        //    var result = await _userManager.ConfirmEmailAsync(user, code);
        //    return result.Succeeded
        //        ? await Result<string>.SuccessAsync(user.Id,
        //            $"Account Confirmed for {user.Email}. You can now use the /api/identity/token endpoint to generate JWT.")
        //        : throw new ApiException(string.Format("An error occurred while confirming {0}", user.Email));
        //}

        //public async Task<IResult> ConfirmEmailAndSetPasswordAsync(ResetPasswordRequest request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    if (user == null)
        //        return await Result.FailAsync("An Error has occured!");

        //    var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));

        //    var result = await _userManager.ResetPasswordAsync(user, code, request.Password);

        //    user.IsActive = true;
        //     await _userManager.UpdateAsync(user);
        //    if (result.Succeeded)
        //    {

        //        var emailConfirmCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //       // code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //        //code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        //        var emailConfirmed = await _userManager.ConfirmEmailAsync(user, emailConfirmCode);
        //        if(emailConfirmed.Succeeded)
        //        {
        //            user.IsActive = true;
        //            var identityResult = await _userManager.UpdateAsync(user);
        //            return await Result.SuccessAsync("Account Confirmed and Password Reset Successful!");
        //        }
        //        return await Result.FailAsync("Account confirmation failed!");
        //    }
        //    return await Result.FailAsync("Account Confirmation and Password Reset Failed!");

        //}

        //public async Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
        //    {
        //        // Don't reveal that the user does not exist or is not confirmed
        //        return await Result.FailAsync("An Error has occurred!");
        //    }

        //    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
        //    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        //    var endpointUri = new Uri(string.Concat($"{_appConfig.FrontEndBaseUrl}", request.IsRequestFromClientApp ? _appConfig.FrontEndClientResetPasswordUrl : _appConfig.FrontEndStaffResetPasswordUrl));
        //    //var passwordResetURL = QueryHelpers.AddQueryString(endpointUri.ToString(), "Token", code);
        //    var mailRequest = new MailRequest
        //    {
        //        Body = $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(endpointUri.AbsoluteUri + code)}'>clicking here</a>.",
        //        Subject = "Reset Password",
        //        To = request.Email
        //    };
        //    await _mailService.SendAsync(mailRequest);
        //    return await Result.SuccessAsync("Password Reset Mail has been sent to your authorized Email.");
        //}

        //public async Task<IResult> ResetPasswordAsync(ResetPasswordRequest request)
        //{
        //    var user = await _userManager.FindByEmailAsync(request.Email);
        //    // Don't reveal that the user does not exist
        //    if (user == null)
        //        return await Result.FailAsync("An Error has occured!");

        //    var code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(request.Token));

        //    var result = await _userManager.ResetPasswordAsync(user, code, request.Password);
        //    return result.Succeeded
        //        ? await Result.SuccessAsync("Password Reset Successful!")
        //        : await Result.FailAsync("Invalid information. Please request reset password again.");
        //}

        //public async Task<int> GetCountAsync()
        //{
        //    var count = await _userManager.Users.CountAsync();
        //    return count;
        //}

        //public async Task<IResult> UpdateUserAsync(string userId, CreateUpdateUserRequest request)
        //{
        //    if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
        //    {
        //        var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Id != userId);
        //        if (userWithSamePhoneNumber != null)
        //            return await Result.FailAsync(string.Format("Phone number {0} is already used.",
        //                request.PhoneNumber));
        //    }

        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null)
        //    {
        //        return await Result.FailAsync("User Not Found.");
        //    }
        //    //user.UserName = request.UserName;
        //    user.PhoneNumber = request.PhoneNumber;
        //    //user.Email = request.Email;
        //    user.FirstName = request.FirstName;
        //    user.LastName = request.LastName;

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    if (request.PhoneNumber != phoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
        //    }
        //    var identityResult = await _userManager.UpdateAsync(user);
        //    var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
        //    await _signInManager.RefreshSignInAsync(user);


        //    if (identityResult.Succeeded)
        //    {
        //        await UpdateRoleAsync(userId, request.Role);
        //        return await Result.SuccessAsync("Profile updated successfully!");
        //    }

        //    return await Result.FailAsync(errors);
        //}

        //public async Task<IResult> InactiveDeleteUserAsync(string id, bool isActive, bool delete)
        //{
        //    var user = await _userManager.FindByIdAsync(id);
        //    user.IsActive = isActive;
        //    user.IsDeleted = delete;
        //    var identityResult = await _userManager.UpdateAsync(user);
        //    if (identityResult.Succeeded)
        //        return await Result.SuccessAsync("Profile updated successfully!");
        //    return await Result.FailAsync("errors");
        //}

        //public async Task<IResult> DeleteAsync(string userId)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);
        //    if (user == null) return await Result.FailAsync("User Not Found.");
        //    user.IsDeleted = true;
        //    user.DeletedOn = DateTime.UtcNow;
        //    var identityResult = await _userManager.UpdateAsync(user);
        //    var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();

        //    return identityResult.Succeeded ? await Result.SuccessAsync("Profile updated successfully!") : await Result.FailAsync(errors);

        //}



        //public async Task<TokenResponse> AuthenticateGoogleUserAsync(GoogleUserRequest request)
        //{
        //    GoogleJsonWebSignature.Payload payload = await ValidateAsync(request.IdToken, new GoogleJsonWebSignature.ValidationSettings
        //    {
        //        Audience = new[] { _googleConfig.ClientId }
        //    });

        //    var user = await GetOrCreateExternalLoginUser(GoogleUserRequest.PROVIDER, payload.Subject, payload.Email, payload.GivenName, payload.FamilyName);

        //    return await GenerateUserToken(user);
        //}


        //private async Task<ApplicationUser> GetOrCreateExternalLoginUser(string provider, string key, string email, string firstName, string lastName)
        //{
        //    var user = await _userManager.FindByLoginAsync(provider, key);
        //    if (user != null)
        //        return user;

        //    user = await _userManager.FindByEmailAsync(email);
        //    if (user != null)
        //        return user;

        //    //if (user == null)
        //    //{
        //    //    user = new AppUser
        //    //    {
        //    //        Email = email,
        //    //        UserName = email,
        //    //        FirstName = firstName,
        //    //        LastName = lastName,
        //    //        Id = key,
        //    //    };
        //    //    await _userManager.CreateAsync(user);
        //    //}

        //    //var info = new UserLoginInfo(provider, key, provider.ToUpperInvariant());
        //    //var result = await _userManager.AddLoginAsync(user, info);
        //    //if (result.Succeeded)
        //    //    return user;
        //    //return null;
        //    return null;
        //}




        //private async Task<TokenResponse> GenerateUserToken(ApplicationUser user)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();

        //    var key = _googleConfig.ClientSecret;

        //    var expires = DateTime.UtcNow.AddDays(7);
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Id),
        //            new Claim(JwtRegisteredClaimNames.Sub, " "),
        //            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
        //            new Claim(ClaimTypes.Name, user.Id),
        //            new Claim(ClaimTypes.Surname, user.FirstName),
        //            new Claim(ClaimTypes.GivenName, user.LastName),
        //            new Claim(ClaimTypes.NameIdentifier, user.UserName),
        //            new Claim(ClaimTypes.Email, user.Email)
        //        }),

        //        Expires = expires,

        //        SigningCredentials =
        //            new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //        Issuer = _googleConfig.ClientId,
        //        Audience = _googleConfig.ClientId
        //    };

        //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        //    var token = tokenHandler.WriteToken(securityToken);

        //    return new TokenResponse
        //    {
        //        //UserId = user.Id,
        //        //Email = user.Email,
        //        Token = token,
        //        RefreshTokenExpiryTime = expires
        //    };
        //}


        //public async Task<string> ExportToExcelAsync(string searchString = "")
        //{
        //    var userSpec = new UserFilterSpecification(searchString);
        //    var users = await _userManager.Users
        //        .Specify(userSpec)
        //        .OrderByDescending(a => a.CreatedOn)
        //        .ToListAsync();
        //    var result = await _excelService.ExportAsync(users, sheetName: "Users",
        //        mappers: new Dictionary<string, Func<ApplicationUser, object>>
        //        {
        //            { "Id", item => item.Id },
        //            { "FirstName", item => item.FirstName },
        //            { "LastName", item => item.LastName },
        //            { "UserName", item => item.UserName },
        //            { "Email", item => item.Email },
        //            { "EmailConfirmed", item => item.EmailConfirmed },
        //            { "PhoneNumber", item => item.PhoneNumber },
        //            { "PhoneNumberConfirmed", item => item.PhoneNumberConfirmed },
        //            { "IsActive", item => item.IsActive },
        //            { "CreatedOn (Local)", item => DateTime.SpecifyKind(item.CreatedOn, DateTimeKind.Utc).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss") },
        //            { "CreatedOn (UTC)", item => item.CreatedOn.ToString("dd/MM/yyyy HH:mm:ss") },
        //        });

        //    return result;
        //}
    }
}
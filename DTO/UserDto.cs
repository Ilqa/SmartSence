using System;
using System.Collections.Generic;

namespace SmartSence.DTO
{
    public class UserDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        //public string Address { get; set; }

        public DateTime CreatedOn { get; set; }
        //public List<string> UserRoles { get; set; } = new();
        public List<string> UserPermissions { get; set; } = new();
        public string Role { get; internal set; }
    }
}

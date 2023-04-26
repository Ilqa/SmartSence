using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using SmartSence.Databse.Entities;

namespace SmartSence.Database.Entities
{
    public class User : IdentityUser<long>
    {
        [ForeignKey("OrganizationId")]
        public Organization? Organization { get; set; }

        public long? OrganizationId { get; set; }
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }


        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedOn { get; set; }
        //public DateTime? ProfileDate { get; set; }
        //public DateTime? InvitationDate { get; set; }
        //public DateTime? ExpiryDate { get; set; }
        //public bool IsDeleted { get; set; }
        //public DateTime? DeletedOn { get; set; }



        //public string RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }
        //

    }
}


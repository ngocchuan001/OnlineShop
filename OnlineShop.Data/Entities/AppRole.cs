using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace OnlineShop.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base()
        {

        }

        public AppRole(string name, string description) : base(name)
        {
            this.Description = description;
        }

        [StringLength(255)]
        public string Description { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Annoucements")]
    public class Announcement: DomainEntity<string>, ISwitchable, IDateTracking
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public Guid SenderId { get; set; }

        [ForeignKey("SenderId")]
        public  virtual AppUser Sender { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
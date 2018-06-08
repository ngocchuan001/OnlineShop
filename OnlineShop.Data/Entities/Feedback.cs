using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Feedbacks")]
    public class Feedback : DomainEntity<int>, ISwitchable, IDateTracking
    {
        public Feedback() { }

        public Feedback(int id, string name, string email, string message, Status status)
        {
            Id = id;
            Name = name;
            Email = email;
            Message = message;
            Status = status;
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
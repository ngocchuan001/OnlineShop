using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Bills")]
    public class Bill : DomainEntity<int>, ISwitchable, IDateTracking
    {
        [Required]
        [MaxLength(255)]
        public string CustomerName { get; set; }

        [Required]
        [MaxLength(255)]
        public string CustomerAddress { get; set; }

        [Required]
        [MaxLength(50)]
        public string CustomerMobile { get; set; }

        [Required]
        [MaxLength(256)]
        public string CustomerMessage { get; set; }

        public Guid? CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public AppUser AppUser { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public BillStatus BillStatus { get; set; }

        [DefaultValue(Enums.Status.Active)]
        public Status Status { get; set; } = Status.Active;

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        public  virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
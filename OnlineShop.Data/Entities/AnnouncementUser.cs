using System;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("AnnouncementUsers")]
    public class AnnouncementUser : DomainEntity<int>
    {
        public string AnouncementId { get; set; }

        public Guid UserId { get; set; }

        public bool?  HasRead { get; set; }

        [ForeignKey("AnouncementId")]
        public virtual Announcement Announcement { set; get; }
    }
}
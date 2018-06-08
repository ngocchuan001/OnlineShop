using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("AdvertistmentPositions")]
    public class AdvertistmentPosition : DomainEntity<string>
    {
        public AdvertistmentPosition()
        {
            Advertistments = new List<Advertistment>();
        }

        [Required]
        [StringLength(20)]
        public string PageId { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("PageId")]
        public virtual  AdvertistmentPage AdvertistmentPage { get; set; }

        public virtual  ICollection<Advertistment> Advertistments { get; set; }

    }
}
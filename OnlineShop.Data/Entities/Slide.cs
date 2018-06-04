using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Slides")]
    public class Slide : DomainEntity<int>
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)]
        [Required]
        public string Image { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        public int? DisplayOrder { get; set; }

        public bool Status { get; set; }

        public string Content { get; set; }

        [StringLength(255)]
        [Required]
        public string GroupAlias { get; set; }
    }
}
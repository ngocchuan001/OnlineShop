using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Functions")]
    public class Function: DomainEntity<string>, ISwitchable, ISortable
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Url { get; set; }

        [StringLength(128)]
        public string ParentId { get; set; }

        [StringLength(255)]
        public string IconCss { get; set; }

        public Status Status { get; set; }
        public int SortOrder { get; set; }
    }
}
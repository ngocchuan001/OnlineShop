using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Colors")]
    public class Color : DomainEntity<int>
    {
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Code { get; set; }

    }
}
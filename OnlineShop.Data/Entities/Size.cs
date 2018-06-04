using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Sizes")]
    public class Size : DomainEntity<int>
    {
        [StringLength(255)]
        public string Name { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Tags")]
    public class Tag : DomainEntity<string>
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Type { get; set; }
    }
}
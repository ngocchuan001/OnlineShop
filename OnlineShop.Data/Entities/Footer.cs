using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Footer")]
    public class Footer : DomainEntity<string>
    {
        [Required]
        public string Content { set; get; }
    }
}
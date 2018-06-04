using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("ProductImages")]
    public class ProductImage : DomainEntity<int>
    {
        public int ProductId { get; set; }

        public string Path { get; set; }

        public string Caption { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

    }
}
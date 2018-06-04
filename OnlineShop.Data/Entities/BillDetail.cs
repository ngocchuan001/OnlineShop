using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("BillDetails")]
    public class BillDetail : DomainEntity<int>
    {
        public int BillId { get; set; }

        public int ProductId { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        [ForeignKey("BillId")]
        public Bill Bill { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [ForeignKey("SizeId")]
        public Size Size { get; set; }

        [ForeignKey("ColorId")]
        public Color Color { get; set; }

    }
}
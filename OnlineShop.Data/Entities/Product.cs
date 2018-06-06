using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        #region COnstructure
        public Product()
        { }

        public Product(string name, int categoryId, string image, decimal price, decimal? promotionPrice, decimal originalPrice, string description, 
            string content, bool? homeFlag, bool? hotFlag, int? viewCount, string tags, string unit, Status status, 
            string seoPageTitle, string seoKeywords, string seoAlias, string seoDescription)
        {
            Name = name;
            CategoryId = categoryId;
            Image = image;
            Price = price;
            PromotionPrice = promotionPrice;
            OriginalPrice = originalPrice;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            ViewCount = viewCount;
            Tags = tags;
            Unit = unit;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoKeywords = seoKeywords;
            SeoAlias = seoAlias;
            SeoDescription = seoDescription;
        }
        #endregion

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }
        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        [StringLength(255)]
        public string Tags { get; set; }

        [StringLength(255)]
        public string Unit { get; set; }

        public Status Status { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        [StringLength(255)]
        public string SeoPageTitle { get; set; }

        [StringLength(255)]
        public string SeoAlias { get; set; }

        [StringLength(255)]
        public string SeoKeywords { get; set; }

        [StringLength(255)]
        public string SeoDescription { get; set; }

        [ForeignKey("CategoryId")]
        public virtual  ProductCategory ProductCategory { get; set; }
    }
}
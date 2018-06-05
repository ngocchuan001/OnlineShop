using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>, IDateTracking, IHasSeoMetaData, ISwitchable, ISortable
    {
        #region Constructure

        public ProductCategory()
        {
            Products = new List<Product>();
        }

        /// <summary>
        /// Constructure for AutoMapper mapping
        /// </summary>
        /// <param name="name"></param>
        public ProductCategory(string name, string decscription, int? parentId, int? homeOrder, string image, bool? homeFlag, 
            string seoPageTitle, string seoAlias, string seoKeywords, string seoDescription, Status status, int sortOrder)
        {
            Name = name;
            Description = decscription;
            ParentId = parentId;
            HomeOrder = homeOrder;
            Image = image;
            HomeFlag = homeFlag;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoKeywords;
            SeoDescription = seoDescription;
            Status = status;
            SortOrder = sortOrder;
        }

        #endregion
        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get;  set; }

        public int? ParentId { get; set; }

        public int? HomeOrder { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }

        public bool? HomeFlag { get; set; }

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

        public Status Status { get; set; }
        public int SortOrder { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}
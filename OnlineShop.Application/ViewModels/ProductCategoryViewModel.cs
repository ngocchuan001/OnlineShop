using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Data.Entities;
using OnlineShop.Data.Enums;

namespace OnlineShop.Application.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

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

        public ICollection<ProductViewModel> Products { get; set; }
    }
}
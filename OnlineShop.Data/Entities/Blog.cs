using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Blogs")]
    public class Blog : DomainEntity<int>, ISwitchable, IDateTracking, IHasSeoMetaData
    {
        public Blog() { }
        public Blog(string name, string thumbnailImage,
           string description, string content, bool? homeFlag, bool? hotFlag,
           string tags, Status status, string seoPageTitle,
           string seoAlias, string seoMetaKeyword,
           string seoMetaDescription)
        {
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }

        public Blog(int id, string name, string thumbnailImage,
             string description, string content, bool? homeFlag, bool? hotFlag,
             string tags, Status status, string seoPageTitle,
             string seoAlias, string seoMetaKeyword,
             string seoMetaDescription)
        {
            Id = id;
            Name = name;
            Image = thumbnailImage;
            Description = description;
            Content = content;
            HomeFlag = homeFlag;
            HotFlag = hotFlag;
            Tags = tags;
            Status = status;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeywords = seoMetaKeyword;
            SeoDescription = seoMetaDescription;
        }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string Content { get; set; }

        public bool? HomeFlag { get; set; }

        public bool? HotFlag { get; set; }

        public int? ViewCount { get; set; }

        public string Tags { get; set; }

        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        [MaxLength(255)]
        public string SeoPageTitle { set; get; }

        [MaxLength(255)]
        public string SeoAlias { set; get; }

        [MaxLength(255)]
        public string SeoKeywords { set; get; }

        [MaxLength(255)]
        public string SeoDescription { set; get; }

        public  virtual ICollection<BlogTag> BlogTags { get; set; }
    }
}
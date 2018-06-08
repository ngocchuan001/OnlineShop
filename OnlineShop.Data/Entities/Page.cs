using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("Pages")]
    public class Page : DomainEntity<int>, ISwitchable
    {
        public Page() { }

        public Page(int id, string name, string alias,
            string content, Status status)
        {
            Id = id;
            Name = name;
            Alias = alias;
            Content = content;
            Status = status;
        }

        [StringLength(255)]
        [Required]
        public string Name { get; set; }

        [StringLength(255)]
        [Required]
        public string Alias { get; set; }

        public string  Content { get; set; }
        public Status Status { get; set; }
    }
}
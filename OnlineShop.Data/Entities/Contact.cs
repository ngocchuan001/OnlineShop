using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineShop.Data.Enums;
using OnlineShop.Data.Interfaces;
using OnlineShop.Infrastructure.SharedKernel;

namespace OnlineShop.Data.Entities
{
    [Table("ContactDetails")]
    public class Contact : DomainEntity<string>, ISwitchable
    {
        public Contact() { }

        public Contact(string id, string name, string phone, string email,
            string website, string address, string other, double? longtitude, double? latitude, Status status)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            WebSite = website;
            Address = address;
            Other = other;
            Lon = longtitude;
            Lat = latitude;
            Status = status;
        }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string WebSite { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public string Other { get; set; }

        public double? Lat { get; set; }

        public double? Lon { get; set; }

        public Status Status { get; set; }
    }
}
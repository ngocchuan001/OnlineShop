using OnlineShop.Data.Enums;

namespace OnlineShop.Data.Interfaces
{
    public interface ISwitchable
    {
        Status Status { get; set; }
    }
}
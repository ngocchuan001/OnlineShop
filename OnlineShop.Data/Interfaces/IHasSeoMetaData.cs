namespace OnlineShop.Data.Interfaces
{
    public interface IHasSeoMetaData
    {
        string PageTitle { get; set; }

        string SeoAlias { get; set; }

        string SeoKeywords { get; set; }

        string SeoDescription { get; set; }
    }
}
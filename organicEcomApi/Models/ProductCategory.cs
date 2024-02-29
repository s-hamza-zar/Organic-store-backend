namespace organicEcomApi.Models
{
    public class ProductCategory
    {
        public int ProductId { get; set; }
        public int CatergoryId { get; set; }

        public Product Product { get; set; }

        public Category Category { get; set; }

    }
}

namespace organicEcomApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public Product Product { get; set; }
    }
}

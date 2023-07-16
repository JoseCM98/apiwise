namespace apiwise.Models.Ecommerce
{
    public class ProductsEcommerce
    {
        public string Id { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxPercent { get; set; }
        public decimal Price { get; set; }
        public decimal Stock { get; set; }
        public string Images { get; set; }
        public string Categories { get; set; }
    }
}

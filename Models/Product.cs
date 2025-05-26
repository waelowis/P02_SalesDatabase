namespace P02_SalesDatabase.Models
{
    class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Decimal Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ICollection<Sale> sales { get; set; } = new List<Sale>();
    }
}

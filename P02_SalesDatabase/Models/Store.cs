namespace P02_SalesDatabase.Models
{
    class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public ICollection<Sale> sales { get; set; } = new List<Sale>();
    }
}

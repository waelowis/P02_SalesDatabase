namespace P02_SalesDatabase.Models
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreaditCardNumber { get; set; }
        public ICollection<Sale> sales { get; set; } = new List<Sale>();
    }
}

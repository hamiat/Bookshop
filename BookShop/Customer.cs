namespace BookShop
{
    public class Customer
    {
        public Customer()
        {
            OrderItems = [];
        }

        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Reseller { get; set; }
        public int CountryId { get; set; }
        public List<string> OrderItems { get; set; }
    }
}

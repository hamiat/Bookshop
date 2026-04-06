namespace Data1
{
    public class Book
    {
        public Book() { }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
        public int ISBN { get; set; }
        public int CountryId { get; set; }

        public decimal Price { get; set; }
        public bool HasDiscount { get; set; }
    }
}

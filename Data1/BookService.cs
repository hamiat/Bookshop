namespace Data1
{
    public class BookService : IBookService
    {
        public void ApplyHalfPriceToOldBooks(List<Book> books, List<string> orderItems)
        {
            var filteredBooks = books.Where(b => orderItems.Contains(b.Title)).ToList();
            foreach (var book in filteredBooks)
            {
                if (book.PublicationYear < 2000)
                {
                    book.Price *= 0.5M;
                    book.HasDiscount = true;
                    Console.WriteLine($"{book.Title} - {book.Author} ({book.PublicationYear})");
                }
            }
        }

        public void ApplyTwoForOneOffer(
            List<Book> books,
            List<string> orderItems,
            List<Country> countries
        )
        {
            var filteredBooks = books.Where(b => orderItems.Contains(b.Title)).ToList();
            var grouped = filteredBooks.Where(b => !b.HasDiscount).GroupBy(b => b.CountryId);

            foreach (var group in grouped)
            {
                if (group.Count() >= 2)
                {
                    var cheapest = group.OrderBy(b => b.Price).First();
                    var mostExpensive = group.OrderByDescending(b => b.Price).First();
                    var countryName = countries.Find(c => c.Id == group.First().CountryId)?.Name;
                    var finalPrice = Math.Round((cheapest.Price + mostExpensive.Price) / 2, 2);

                    Console.WriteLine(
                        $"50% off 2 books ({cheapest.Title} and {mostExpensive.Title}) from {countryName}: {finalPrice} euros."
                    );
                }
            }
        }
    }
}

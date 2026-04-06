namespace BookShop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> bookList = Data.GetBooks();
            List<Customer> customers = Data.GetCustomers();
            List<Country> countries = Data.GetCountries();

            IBookService bookService = new BookService();

            foreach (var customer in customers)
            {
                if (customer.Reseller)
                {
                    Console.WriteLine(
                        $"***{customer.CompanyName}: Special Reseller discount this month! Half Price on each book!*** \n"
                    );
                    bookService.ApplyHalfPriceToOldBooks(bookList, customer.OrderItems);
                }
                else if (
                    bookList.Any(b =>
                        b.CountryId == customer.CountryId && customer.OrderItems.Contains(b.Title)
                    )
                )
                {
                    Console.WriteLine(
                        $"***{customer.CompanyName}: Celebrating your country's authors this month!*** \n"
                    );
                    bookService.ApplyTwoForOneOffer(bookList, customer.OrderItems, countries);
                }
            }
        }
    }
}

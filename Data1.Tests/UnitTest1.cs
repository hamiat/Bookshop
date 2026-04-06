namespace Data1.Tests
{
    [TestFixture]
    public class BookServiceTests
    {
        private BookService _bookService;

        [SetUp]
        public void SetUp()
        {
            _bookService = new BookService();
        }

        private List<Book> GetTestBooks() => new()
        {
            new Book { Id = 1, Title = "Kafka On The Shore", Author = "Haruki Murakami", PublicationYear = 2002, CountryId = 5, Price = 20.25M, HasDiscount = false },
            new Book { Id = 2, Title = "Giovanni's Room", Author = "James Baldwin", PublicationYear = 1956, CountryId = 9, Price = 15.00M, HasDiscount = false },
            new Book { Id = 3, Title = "Wuthering Heights", Author = "Emily Brontë", PublicationYear = 1847, CountryId = 10, Price = 16.01M, HasDiscount = false },
            new Book { Id = 4, Title = "Half of a Yellow Sun", Author = "Chimamanda Ngozi Adichie", PublicationYear = 2006, CountryId = 2, Price = 18.20M, HasDiscount = false },
            new Book { Id = 5, Title = "Purple Hibiscus", Author = "Chimamanda Ngozi Adichie", PublicationYear = 2003, CountryId = 2, Price = 21.05M, HasDiscount = false },
        };

        private List<Country> GetTestCountries() => new()
        {
            new Country { Id = 2, Name = "Nigeria", Code = "NG" },
            new Country { Id = 5, Name = "Japan", Code = "JP" },
            new Country { Id = 9, Name = "United States", Code = "US" },
            new Country { Id = 10, Name = "United Kingdom", Code = "UK" },
        };

        // --- ApplyHalfPriceToOldBooks ---

        [Test]
        public void ApplyHalfPrice_ShouldDiscountBooksPublishedBefore2000()
        {
            var books = GetTestBooks();
            var orderItems = new List<string> { "Giovanni's Room", "Wuthering Heights" };

            _bookService.ApplyHalfPriceToOldBooks(books, orderItems);

            var giovanni = books.First(b => b.Title == "Giovanni's Room");
            var wuthering = books.First(b => b.Title == "Wuthering Heights");

            Assert.That(giovanni.Price, Is.EqualTo(7.50M), 
                "Giovanni's Room (1956) should be halved from 15.00 to 7.50");
            Assert.That(wuthering.Price, Is.EqualTo(8.005M), 
                "Wuthering Heights (1847) should be halved from 16.01 to 8.005");
        }

        [Test]
        public void ApplyHalfPrice_ShouldNotDiscountBooksFrom2000OrLater()
        {
            var books = GetTestBooks();
            var orderItems = new List<string> { "Kafka On The Shore" };

            _bookService.ApplyHalfPriceToOldBooks(books, orderItems);

            var kafka = books.First(b => b.Title == "Kafka On The Shore");
            Assert.That(kafka.Price, Is.EqualTo(20.25M), 
                "Kafka On The Shore (2002) should remain at full price 20.25 since it was published after 2000");
        }

        // --- ApplyTwoForOneOffer ---

        [Test]
        public void ApplyTwoForOne_ShouldCalculateCorrectFinalPrice_ForTwoBooksFromSameCountry()
        {
            var books = GetTestBooks();
            var countries = GetTestCountries();
            var orderItems = new List<string> { "Half of a Yellow Sun", "Purple Hibiscus" };

            var output = new StringWriter();
            Console.SetOut(output);

            _bookService.ApplyTwoForOneOffer(books, orderItems, countries);

            var result = output.ToString();
            Assert.That(result, Does.Contain("Nigeria"), 
                "Output should mention the country name Nigeria");
            Assert.That(result, Does.Contain("19,62").Or.Contain("19.62"), 
                "Final price should be 19.62 — the average of 18.20 (Half of a Yellow Sun) and 21.05 (Purple Hibiscus)");
        }

        [Test]
        public void ApplyTwoForOne_ShouldNotApplyOffer_WhenFewerThanTwoBooksFromSameCountry()
        {
            var books = GetTestBooks();
            var countries = GetTestCountries();
            var orderItems = new List<string> { "Kafka On The Shore" }; // only 1 Japanese book

            var output = new StringWriter();
            Console.SetOut(output);

            _bookService.ApplyTwoForOneOffer(books, orderItems, countries);

            Assert.That(output.ToString().Trim(), Is.Empty, 
                "No output expected — only 1 Japanese book in the order, so the two-for-one cannot trigger");
        }

        [Test]
        public void ApplyTwoForOne_ShouldSkipBooksAlreadyDiscounted()
        {
            var books = GetTestBooks();
            var countries = GetTestCountries();

            books.First(b => b.Title == "Purple Hibiscus").HasDiscount = true;

            var orderItems = new List<string> { "Half of a Yellow Sun", "Purple Hibiscus" };

            var output = new StringWriter();
            Console.SetOut(output);

            _bookService.ApplyTwoForOneOffer(books, orderItems, countries);

            Assert.That(output.ToString().Trim(), Is.Empty, 
                "No output expected — Purple Hibiscus already has a discount, leaving only 1 eligible Nigerian book");
        }
    }
}
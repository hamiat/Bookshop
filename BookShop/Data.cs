namespace BookShop
{
    public static class Data
    {
        public static List<Book> GetBooks()
        {
            List<Book> books = [];

            Book book = new()
            {
                Id = 1,
                Title = "Kafka On The Shore",
                Author = "Haruki Murakami",
                Description = "Coming of age story about self-discovery.",
                PublicationYear = 2002,
                ISBN = 1012101210,
                CountryId = 5,
                Price = 20.25M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 2,
                Title = "Half of a Yellow Sun",
                Author = "Chimamanda Ngozi Adichie",
                Description =
                    "Historical novel detailing the lives of several characters navigating love, trauma, and betrayal during the brutal Nigerian-Biafran civil war of the late 1960s",
                PublicationYear = 2006,
                ISBN = 1024101230,
                CountryId = 2,
                Price = 18.20M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 3,
                Title = "Purple Hibiscus",
                Author = "Chimamanda Ngozi Adichie",
                Description =
                    "Coming of age story about privilege and oppression in Enugu, Nigeria.",
                PublicationYear = 2003,
                ISBN = 1012491213,
                CountryId = 2,
                Price = 21.05M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 4,
                Title = "Giovanni's Room",
                Author = "James Baldwin",
                Description =
                    "Doomed love affair in 1950s Paris, focusing on themes of internalized homophobia, self-loathing, and the societal pressures that prevent authentic love.",
                PublicationYear = 1956,
                ISBN = 1092481218,
                CountryId = 9,
                Price = 15.00M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 5,
                Title = "Wuthering Heights",
                Author = "Emily Brontë",
                Description =
                    "A gothic tale of intense, destructive passion and vengeful obsession centered on the stormy relationship.",
                PublicationYear = 1847,
                ISBN = 1152141620,
                CountryId = 10,
                Price = 16.01M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 6,
                Title = "Oliver Twist",
                Author = "Charles Dickens",
                Description =
                    "struggles against poverty and crime to eventually find a loving home.",
                PublicationYear = 1837,
                ISBN = 1152141657,
                CountryId = 10,
                Price = 16.22M,
                HasDiscount = false,
            };
            books.Add(book);
            book = new()
            {
                Id = 7,
                Title = "Convenience Store Woman",
                Author = "Sayaka Murata",
                Description =
                    "An ironic and sharp-eyed look at contemporary work culture and the pressures we all feel to conform.",
                PublicationYear = 2016,
                ISBN = 1452141689,
                CountryId = 5,
                Price = 25.22M,
                HasDiscount = false,
            };
            books.Add(book);

            return books;
        }

        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = [];

            Customer customer = new()
            {
                Id = 1,
                CompanyName = "Coffee & Books",
                Email = "cb@cb.se",
                Reseller = false,
                CountryId = 5,
                OrderItems =
                [
                    "Kafka On The Shore",
                    "Giovanni's Room",
                    "Wuthering Heights",
                    "Convenience Store Woman",
                ],
            };
            customers.Add(customer);
            customer = new()
            {
                Id = 2,
                CompanyName = "Book Bus",
                Email = "bb@bb.se",
                Reseller = true,
                CountryId = 9,
                OrderItems =
                [
                    "Giovanni's Room",
                    "Kafka On The Shore",
                    "Purple Hibiscus",
                    "Oliver Twist",
                ],
            };
            customers.Add(customer);
            customer = new()
            {
                Id = 3,
                CompanyName = "Book Clubbing",
                Email = "bc@bc.se",
                Reseller = false,
                CountryId = 2,
                OrderItems = ["Kafka On The Shore", "Purple Hibiscus", "Half of a Yellow Sun"],
            };
            customers.Add(customer);

            return customers;
        }

        public static List<Country> GetCountries()
        {
            List<Country> countries = [];

            Country country = new()
            {
                Id = 1,
                Name = "Sweden",
                Code = "SE",
            };
            countries.Add(country);
            country = new()
            {
                Id = 2,
                Name = "Nigeria",
                Code = "NG",
            };
            countries.Add(country);
            country = new()
            {
                Id = 5,
                Name = "Japan",
                Code = "JP",
            };
            countries.Add(country);
            country = new()
            {
                Id = 9,
                Name = "United States",
                Code = "US",
            };
            countries.Add(country);
            country = new()
            {
                Id = 10,
                Name = "United Kingdom",
                Code = "UK",
            };
            countries.Add(country);

            return countries;
        }
    }
}

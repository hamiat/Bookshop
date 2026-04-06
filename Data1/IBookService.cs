namespace Data1
{
    public interface IBookService
    {
        void ApplyHalfPriceToOldBooks(List<Book> books, List<string> orderItems);
        void ApplyTwoForOneOffer(List<Book> books, List<string> orderItems, List<Country> countries);
    }
}
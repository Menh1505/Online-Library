namespace OnlineLibrary.Models
{
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }

    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public void AddItem(Book book, int quantity)
        {
            CartLine? line = Lines.Where(l => l.Book.BookId == book.BookId).FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Book book) =>
            Lines.RemoveAll(l => l.Book.BookId == book.BookId);
        public decimal ComputeTotalValues() => 
            (decimal)Lines.Sum(l => l.Book?.SellPrice * (1 - l.Book?.DiscountAmount) * l.Quantity);
        public void Clear() =>
            Lines.Clear();
    }
}
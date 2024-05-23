namespace Books.Services
{
    public class BooksService
    {
        private readonly List<Book> _books;

        public BooksService()
        {
            _books = new List<Book>
            {
                new Book { Id = 0, Title = "1984", Author = "George Orwell", Genre = "Dystopian" }
            };
        }

        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id) => _books.FirstOrDefault(b => b.Id == id);
        public void Add(Book book) => _books.Add(book);
        public void Update(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
        }
        public void Delete(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                _books.RemoveAt(index);
            }
        }
    }
}

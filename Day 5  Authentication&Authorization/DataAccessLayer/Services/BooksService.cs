using DataAccessLayer.Models;

namespace DataAccessLayer.BooksService
{
    public class BooksService
    {
        private readonly List<Book> _books;

        public BooksService()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = " Introduction to Algorithms", Author = "Cormen", Genre = "Technology" },
                new Book { Id = 2, Title = " Clean Code",
                Author = "Robert C. Martin", Genre = "Coding" }
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

        public void Delete(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}

using PopePhransisBookStore.Model;

namespace PopePhransisBookStore.Repository
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book book);
        Task<Book> GetBook(int id);
        Task<List<Book>>ListOfBooks();
        Task<Book> UpdateBook(Book book);
        bool DeleteBook(int id);
        


    }
}

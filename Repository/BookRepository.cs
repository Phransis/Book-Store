using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PopePhransisBookStore.Model;

namespace PopePhransisBookStore.Repository
{
   
        public class BookRepository : IBookRepository
        {
            private Dictionary<int, Book> allBooks;

            public BookRepository()
            {
                allBooks = new Dictionary<int, Book>();

                // Seed some books for testing
                allBooks[1] = new Book { Id = 1, BookName = "FB", Category = "1", Description = "", Price = 3 };
                allBooks[2] = new Book { Id = 2, BookName = "SB", Category = "2", Description = "", Price = 3 };
                allBooks[3] = new Book { Id = 3, BookName = "TB", Category = "1", Description = "", Price = 3 };
                allBooks[4] = new Book { Id = 4, BookName = "4B", Category = "2", Description = "", Price = 3 };
                allBooks[5] = new Book { Id = 5, BookName = "5B", Category = "1", Description = "", Price = 3 };
                allBooks[6] = new Book { Id = 6, BookName = "6B", Category = "2", Description = "", Price = 3 };
                allBooks[7] = new Book { Id = 7, BookName = "7B", Category = "1", Description = "", Price = 3 };
                allBooks[8] = new Book { Id = 8, BookName = "8D", Category = "2", Description = "", Price = 3 };
            }

            // Create a new book
            public Task<Book> CreateBook(Book book)
            {
                if (book.Id == 0)
                {
                    int key = allBooks.Count + 1;
                    while (allBooks.ContainsKey(key)) { key++; }
                    book.Id = key;
                }
                allBooks[book.Id] = book;
                return Task.FromResult(book);
            }

            // Get a book by ID
            public Task<Book> GetBook(int id)
            {
                if (allBooks.ContainsKey(id))
                {
                    return Task.FromResult(allBooks[id]);
                }
                return Task.FromResult<Book>(null);  // Return null if the book is not found
            }

     
            public Task<List<Book>> ListOfBooks()
            {
                var books = allBooks.Values.ToList(); // Convert dictionary values to a list
                return Task.FromResult(books);
            }

            // Update book details
            public Task<Book> UpdateBook(Book updatedBook)
            {
                if (allBooks.ContainsKey(updatedBook.Id))
                {
                    var existingBook = allBooks[updatedBook.Id];
                    existingBook.BookName = updatedBook.BookName;
                    existingBook.Category = updatedBook.Category;
                    existingBook.Description = updatedBook.Description;
                    existingBook.Price = updatedBook.Price;

                    return Task.FromResult(existingBook); // Return the updated book
                }

                return Task.FromResult<Book>(null); // Return null if the book does not exist
            }

            // Delete a book by ID
            public bool DeleteBook(int id)
            {
                if (allBooks.ContainsKey(id))
                {
                    allBooks.Remove(id);
                    return true; // Book successfully deleted
                }
                return false; // Book not found
            }
        }
    }



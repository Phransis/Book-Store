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

                allBooks[1] = new Book { Id = 1, BookName = "FB", Category = "1", Description = "", Price = 3 };
                allBooks[2] = new Book { Id = 2, BookName = "SB", Category = "2", Description = "", Price = 3 };
                allBooks[3] = new Book { Id = 3, BookName = "TB", Category = "1", Description = "", Price = 3 };
                allBooks[4] = new Book { Id = 4, BookName = "4B", Category = "2", Description = "", Price = 3 };
                allBooks[5] = new Book { Id = 5, BookName = "5B", Category = "1", Description = "", Price = 3 };
                allBooks[6] = new Book { Id = 6, BookName = "6B", Category = "2", Description = "", Price = 3 };
                allBooks[7] = new Book { Id = 7, BookName = "7B", Category = "1", Description = "", Price = 3 };
                allBooks[8] = new Book { Id = 8, BookName = "8D", Category = "2", Description = "", Price = 3 };
            }

           
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

            public Task<Book> GetBook(int id)
            {
                if (allBooks.ContainsKey(id))
                {
                    return Task.FromResult(allBooks[id]);
                }
                return Task.FromResult<Book>(null);  
            }

     
            public Task<List<Book>> ListOfBooks()
            {
                var books = allBooks.Values.ToList(); 
                return Task.FromResult(books);
            }

          
            public Task<Book> UpdateBook(Book updatedBook)
            {
                if (allBooks.ContainsKey(updatedBook.Id))
                {
                    var existingBook = allBooks[updatedBook.Id];
                    existingBook.BookName = updatedBook.BookName;
                    existingBook.Category = updatedBook.Category;
                    existingBook.Description = updatedBook.Description;
                    existingBook.Price = updatedBook.Price;

                    return Task.FromResult(existingBook); 
                }

                return Task.FromResult<Book>(null); 
            }

         
            public bool DeleteBook(int id)
            {
                if (allBooks.ContainsKey(id))
                {
                    allBooks.Remove(id);
                    return true; 
                }
                return false; 
            }
        }
    }



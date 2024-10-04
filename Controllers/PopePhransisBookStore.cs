using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PopePhransisBookStore.Model;
using PopePhransisBookStore.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PopePhransisBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopePhransisBookStore : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public PopePhransisBookStore(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        // POST: api/PopePhransisBookStore/CreateBook
        [HttpPost("CreateBook")]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book is null.");
            }

            var createdBook = await bookRepository.CreateBook(book);
            return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
        }

        // GET: api/PopePhransisBookStore/GetBook/1
        [HttpGet("GetBook/{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // GET: api/PopePhransisBookStore/ListOfBooks
        [HttpGet("ListOfBooks")]
        public async Task<ActionResult<List<Book>>> ListOfBooks()
        {
            var books = await bookRepository.ListOfBooks();
            return Ok(books);
        }

        // PUT: api/PopePhransisBookStore/UpdateBook/1
        [HttpPut("UpdateBook/{id}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book updatedBook)
        {
            if (updatedBook == null || updatedBook.Id != id)
            {
                return BadRequest();
            }

            var book = await bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var result = await bookRepository.UpdateBook(updatedBook);
            return Ok(result);
        }

        // DELETE: api/PopePhransisBookStore/DeleteBook/1
        [HttpDelete("DeleteBook/{id}")]
        public ActionResult DeleteBook(int id)
        {
            var isDeleted = bookRepository.DeleteBook(id);
            if (isDeleted)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

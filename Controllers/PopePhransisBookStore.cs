using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PopePhransisBookStore.Model;
using PopePhransisBookStore.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace PopePhransisBookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopePhransisBookStore(IBookRepository bookRepository) : ControllerBase
    {
        private readonly IBookRepository bookRepository = bookRepository;


        [Authorize]
        
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

        [Authorize]
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

        [Authorize]
        [HttpGet("ListOfBooks")]
        public async Task<ActionResult<List<Book>>> ListOfBooks()
        {
            var books = await bookRepository.ListOfBooks();
            return Ok(books);
        }

        
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


        [HttpDelete("DeleteBook/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var isDeleted = await bookRepository.DeleteBook(id); 
            if (isDeleted)
            {
                return Ok(); 
            }
            return NotFound(); 
        }

    }
}

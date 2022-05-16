using BooksSoreApp.Managers;
using BooksSoreApp.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BooksSoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        /// <summary>
        /// get all books
        /// </summary>
        /// <returns></returns>
        [EnableCors("AllowOrigin")]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _bookManager.GetAllBooks();
                if (books == null) return NotFound();
                return Ok(books);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get book by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                var employees = _bookManager.GetBookById(id);
                if (employees == null) return NotFound();
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// create a book
        /// </summary>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateBook([FromBody] BookModel bookModel)
        {
            try
            {
                var bookResource = _bookManager.CreateBook(bookModel);
                return Ok(bookResource);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// update a book
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bookModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateBook(int id, [FromBody] BookModel bookModel)
        {
            try
            {
                var bookResource = _bookManager.UpdateBook(id, bookModel);
                return Ok(bookResource);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete a book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _bookManager.DeleteBook(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

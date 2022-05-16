using BooksSoreApp.Managers;
using BooksSoreApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BooksSoreApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorManager _authorManager;

        public AuthorController(IAuthorManager authorManager)
        {
            _authorManager = authorManager;
        }

        /// <summary>
        /// get all authors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllAuthors()
        {
            try
            {
                var authors = _authorManager.GetAllAuthors();
                if (authors == null) return NotFound();
                return Ok(authors);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// get author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetAuthorById(int id)
        {
            try
            {
                var author = _authorManager.GetAuthorById(id);
                if (author == null) return NotFound();
                return Ok(author);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// create an author
        /// </summary>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateAuthor([FromBody] AuthorModel authorModel)
        {
            try
            {
                var authorResource = _authorManager.CreateAuthor(authorModel);
                return Ok(authorResource);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// update an author
        /// </summary>
        /// <param name="id"></param>
        /// <param name="authorModel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorModel authorModel)
        {
            try
            {
                var authorResource = _authorManager.UpdateAuthor(id, authorModel);
                return Ok(authorResource);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// delete an author
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("[action]")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorManager.DeleteAuthor(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

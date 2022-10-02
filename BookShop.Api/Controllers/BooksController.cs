namespace BookShop.Api.Controllers
{
    using BookShop.Api.Models.Books;
    using BookShop.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class BooksController : BaseController
    {
        public readonly IBookService books;
        public readonly IAuthorService authors;

        public BooksController(IBookService booksFromMethod, IAuthorService authors)
        {
            this.books = booksFromMethod;
            this.authors = authors;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.Ok(await books.Details(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] string search = "")
        {
            return Ok(await this.books.AllBooks(search));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBookRequestModel model)
        {
            if (!await this.authors.Exists(model.AuthorId))
            {
                return BadRequest("Author does not exist.");
            }

            int id = await this.books.CreateBook(
                model.Title,
                model.Description,
                model.Price,
                model.Copies,
                model.Edition,
                model.AgeRestriction,
                model.ReleaseDate,
                model.AuthorId,
                model.Categories
                );

            return Ok(id);
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (!await this.books.Exist(id))
            {
                return BadRequest("The searched book is not exist");
            }
            else
            {
                await this.books.DeleteThisBook(id);
                return Ok("Book is successfully deleted.");
            }
        }
    }
}

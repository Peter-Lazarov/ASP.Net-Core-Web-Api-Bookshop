namespace BookShop.Api.Controllers
{
    using BookShop.Api.Models.Authors;
    using BookShop.Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class AuthorsController : BaseController
    {
        public readonly IAuthorService authors;

        public AuthorsController(IAuthorService authorsForMethod)
        {
            this.authors = authorsForMethod;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return this.Ok(await authors.Details(id));
        }

        [HttpGet("{id}/books")]
        public async Task<IActionResult> GetAndBooks(int id)
        {
            return this.Ok(await authors.AuthorAndBooks(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostAuthorRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = await this.authors.Create(model.FirstName, model.LastName);

            return Ok(id);
        }
    }
}

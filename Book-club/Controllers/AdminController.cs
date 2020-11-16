using Microsoft.AspNetCore.Mvc;
using Book.Application.BooksAdmin;
using Book.Database;
using System.Threading.Tasks;

namespace Book_club.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDbContext _ctx;
        public AdminController(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("books")]
        public IActionResult GetBooks() =>Ok(new GetBooks(_ctx).Show());

        [HttpGet("books/{id}")]
        public IActionResult GetBook(int id) => Ok(new GetBook(_ctx).ShowOne(id));

        [HttpPost("books")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBook.Request request) => Ok((await new CreateBook(_ctx).AddOne(request)));

        [HttpDelete("books/{id}")]
        public async Task<IActionResult> DeleteBook(int id) => Ok((await new DeleteBook(_ctx).Delete(id)));

        [HttpPut("books")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBook.Request request) => Ok((await new UpdateBook(_ctx).Update(request)));
    }
}

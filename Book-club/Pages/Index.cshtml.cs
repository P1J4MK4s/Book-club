using System.Collections.Generic;
using Book.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GetBooks = Book.Application.Book.GetBooks;

namespace Book_club.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _ctx;
        public IndexModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<GetBooks.BookViewModel> Books { get; set; }

        public void OnGet()
        {
           Books = new GetBooks(_ctx).Show();
        }
    }
}

using Book.Application.Books;
using Book.Application.MyLibrary;
using Book.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_club.Pages
{
    public class BookModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public BookModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        [BindProperty]
        public AddToMyLibrary.Request MyLibraryViewModel { get; set; }
        public GetBook.BookViewModel Book { get; set; }
        public IActionResult OnGet(string title)
        {
            Book = new GetBook(_ctx).Show(title.Replace("_"," "));
            if (Book == null) return RedirectToPage("Index");
            else return Page();
        }
        public IActionResult OnPost()
        {
            new AddToMyLibrary(HttpContext.Session).Add(MyLibraryViewModel);

            return RedirectToPage("MyLibrary");
        }
    }
}

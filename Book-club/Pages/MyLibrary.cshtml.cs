using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book.Application.MyLibrary;
using Book.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book_club.Pages
{
    public class MyLibraryModel : PageModel
    {
        private ApplicationDbContext _ctx;

        public MyLibraryModel(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
         public IEnumerable<GetMyLibrary.Response> MyLibrary { get; set; }
        public IActionResult OnGet()
        {
            MyLibrary = new GetMyLibrary(HttpContext.Session, _ctx).Show();

            return Page();
        }
    }
}

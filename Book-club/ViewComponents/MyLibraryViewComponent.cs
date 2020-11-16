using Book.Application.MyLibrary;
using Book.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_club.ViewComponents
{
    public class MyLibraryViewComponent : ViewComponent
    {
        private ApplicationDbContext _ctx;

        public MyLibraryViewComponent(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IViewComponentResult Invoke(string view = "Default")
        {
            return View(view,new GetMyLibrary(HttpContext.Session, _ctx).Show());
        }
    }
}

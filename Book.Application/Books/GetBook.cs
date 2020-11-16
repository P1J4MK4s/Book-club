using Book.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Book.Application.Books
{
    public class GetBook
    {
        private ApplicationDbContext _ctx;

        public GetBook(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public BookViewModel Show(string title) =>
            _ctx.Books
            .Where(x => x.Title == title)
            .Select(x => new BookViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Author = x.Author,
                Description = x.Description
            }).FirstOrDefault();
        public class BookViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }

        }
    }
}

using Book.Database;
using System.Collections.Generic;
using System.Linq;

namespace Book.Application.Book
{
    public class GetBooks
    {
        private ApplicationDbContext _ctx;

        public GetBooks(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<BookViewModel> Show() => _ctx.Books.ToList().Select(x => new BookViewModel
        {
            Title = x.Title,
            Author = x.Author,
            Description = x.Description
        });
        public class BookViewModel
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }

        }
    }
}

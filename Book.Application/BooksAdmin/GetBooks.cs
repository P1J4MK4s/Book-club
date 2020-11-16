using Book.Database;
using System.Collections.Generic;
using System.Linq;

namespace Book.Application.BooksAdmin
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
            Id = x.Id,
            Title = x.Title,
            Author = x.Author,
            Description = x.Description
        });
        public class BookViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }

        }
    }
}

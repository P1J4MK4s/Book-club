using Book.Database;
using System.Linq;
using System.Threading.Tasks;

namespace Book.Application.BooksAdmin
{
    public class UpdateBook
    {
        private ApplicationDbContext _context;
        public UpdateBook(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Response> Update(Request request)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == request.Id);

            book.Title = request.Title;
            book.Author = request.Author;
            book.Description = request.Description;

            await _context.SaveChangesAsync();
            return new Response
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description
            };
        }
        public class Request
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }

        }
        public class Response
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }

        }
    }
}

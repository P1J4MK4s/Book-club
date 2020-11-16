using Book.Database;
using Book.Domain.Models;
using System.Threading.Tasks;

namespace Book.Application.BooksAdmin
{
    public class CreateBook
    {
        private ApplicationDbContext _context;
        public CreateBook(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<Response> AddOne(Request vm)
        {
            var book = new ABook
            {
                Title = vm.Title,
                Author = vm.Author,
                Description = vm.Description
            };

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return new Response
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
            };
        }
        public class Request
        {
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

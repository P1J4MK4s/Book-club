using Book.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Application.BooksAdmin
{
    public class DeleteBook
    {
        private ApplicationDbContext _context;
        public DeleteBook(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var Book = _context.Books.FirstOrDefault(x => x.Id == id);
            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            // Books - BookModel conversion. Later we substitute it with automapper
            var records = await _context.Books.Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();
            return records;
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            // Books - BookModel conversion. Later we substitute it with automapper
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return record;
        }
        public async Task<int> AddBookAsync(BookModel bookModel)
        {
            //id will be added by entity framework automatically
            var book = new Book
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
    }
}

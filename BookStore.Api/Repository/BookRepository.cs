using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        public BookRepository(BookStoreContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            /* Books - BookModel conversion. Later we substitute it with automapper
            var records = await _context.Books.Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).ToListAsync();
            return records;*/
            var records = await _context.Books.ToListAsync();
            //target - source
            return _mapper.Map<List<BookModel>>(records);
        }
        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            /* Books - BookModel conversion. Later we substitute it with automapper
            var record = await _context.Books.Where(x => x.Id == bookId).Select(x => new BookModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            }).FirstOrDefaultAsync();
            return record; */
            var book = await _context.Books.FindAsync(bookId);
            //target - source
            return _mapper.Map<BookModel>(book);
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
        public async Task UpdateBookAsync(int bookId, BookModel bookModel)
        {
            /*hits db twice, where _context exists
            var book = await _context.Books.FindAsync(bookId);
            if (book != null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;
                await _context.SaveChangesAsync();
            } */
            //Second method - hits db once
            var book = new Book
            {
                Id = bookId,
                Title = bookModel.Title,
                Description = bookModel.Description
            };
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBookPatchAsync(int bookId, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookId);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<int> DeleteBookAsync(int bookId)
        {            
            var book = await _context.Books.FindAsync(bookId);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
    }
}

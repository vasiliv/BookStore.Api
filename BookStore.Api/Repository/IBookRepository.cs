using BookStore.Api.Data;
using BookStore.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Api.Repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int bookId);
    }
}

using AutoMapper;
using BookStore.Api.Data;
using BookStore.Api.Models;

namespace BookStore.Api.Helpers
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}

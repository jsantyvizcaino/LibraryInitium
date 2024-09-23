using AutoMapper;
using Bookstore.Application.DTOs.Book;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrestructure.Mapping
{
    internal class BookProfile:Profile
    {
        public BookProfile()
        {
            CreateMap<Book,BookReadDto>().ReverseMap();
            CreateMap<Book,BookCreateDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using Bookstore.Application.DTOs.User;
using Bookstore.Domain.Entities;

namespace Bookstore.Infrestructure.Mapping
{
    internal class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<Usuario, UserReadDto>().ReverseMap();
            CreateMap<Usuario, UserCreateDto>().ReverseMap();
        }
    }
}

using Bookstore.Application.DTOs.User;
using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace Bookstore.Application.Features.Users.Queries
{
    public class UsersQuery : IRequest<IReadOnlyCollection<UserReadDto>>
    {
        public ODataQueryOptions<UserReadDto> Filtros { get; set; }

        public UsersQuery(ODataQueryOptions<UserReadDto> filtros)
        {
            Filtros = filtros;
        }
    }
}

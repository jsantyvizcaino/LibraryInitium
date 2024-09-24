using Bookstore.Domain.Interfaces;
using Bookstore.Infrestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookstore.Infrestructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddIfraServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<LibraryContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("BookstoreCon")));
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();

            return serviceCollection;
        }
    }
}

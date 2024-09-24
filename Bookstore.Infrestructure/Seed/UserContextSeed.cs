using Bookstore.Application.DTOs;
using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bookstore.Infrestructure.Seed
{
    public class UserContextSeed
    {
        public static async Task SeedAsync(LibraryContext context, ILogger<UserContextSeed> logger, IOptions<AppSettings> configuration)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.AddRange(GetUsers(configuration.Value));
                await context.SaveChangesAsync();
                logger.LogInformation($"Usuario Table: {typeof(LibraryContext).Name} seeded.");
            }
        }

        private static IEnumerable<Usuario> GetUsers(AppSettings configuration)
        {
            var password = "Test.2025!";
            var passwordEncripted = SecurityManager.EncryptPassword(password, configuration.EncryptionSettings.Key, configuration.EncryptionSettings.IV);
            return new List<Usuario>
        {
            new()
            {
                Username = "svizcaino",
                FullName = "Santiago Vizcaíno",
                Email = "jorgesantiagovizcaino@gmail.com",
                Password = passwordEncripted,
               
            }
        };
        }
    }
}

using Bookstore.Application.DTOs.Book;

namespace Bookstore.Application.DTOs.User
{
    public class UserReadDto
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

       

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<BookReadDto> Books { get; set; } = new List<BookReadDto>();
    }
}

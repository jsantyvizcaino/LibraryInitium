﻿namespace Bookstore.Application.DTOs.User
{
    public class UserCreateDto
    {
        

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }
}

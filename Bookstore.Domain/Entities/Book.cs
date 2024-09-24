﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Author { get; set; } = null!;

        public int PublishedYear { get; set; }

        public string Genre { get; set; } = null!;

        public int? UsuarioId { get; set; }

        public virtual Usuario? Usuario { get; set; }

    }
}

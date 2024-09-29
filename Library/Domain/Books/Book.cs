using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Domain.Primitives;

namespace eLibrary.Library.Domain.Books
{
    public class Book : Entity<Guid>
    {
        public string Isbn { get; private set; }
        public string Name { get; private set; }
        public string Author { get; private set; }
        public string Place { get; private set; }
        public decimal Count { get; private set; }

        public Book(string isbn, string name, string author, string place, decimal count)
            : base(Guid.NewGuid())
        {
            Isbn = isbn;
            Name = name;
            Author = author;
            Place = place;
            Count = count;
        }
    }
}
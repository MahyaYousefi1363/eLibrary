using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eLibrary.Library.Application.Books.Dtos
{
    public record BookForCreateDto(
        string Isbn,
        string Name,
        string Author,
        string Place,
        decimal Count
    );
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eLibrary.Library.Domain.Books;
using eLibrary.Library.Application.Books.Dtos;

namespace eLibrary.Library.Application.Books
{
    public class BookMapper: Profile
    {
        public BookMapper()
        {
            CreateMap<Book,BookForCreateDto>();
        }
    }
}
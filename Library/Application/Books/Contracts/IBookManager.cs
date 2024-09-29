using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Books.Dtos;
namespace eLibrary.Library.Application.Books.Contracts
{
    public interface IBookManager
    {
        Task<Result> CreateBookAsync(BookForCreateDto bookForCreateDto);
    }
}
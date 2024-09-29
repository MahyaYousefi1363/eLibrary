using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using CSharpFunctionalExtensions;
using eLibrary.Library.Application.Books.Contracts;
using eLibrary.Library.Application.Books.Dtos;
using eLibrary.Library.Domain.Primitives.Contracts;
using eLibrary.Library.Domain.Books;

namespace eLibrary.Library.Application.Books
{
    public class BookManager(
        IBookRepository bookRepository
        ,IMapper mapper
        ,IValidator<BookForCreateDto> bookForCreateValidator
    ) : IBookManager
    {
        public async Task<Result> CreateBookAsync(BookForCreateDto bookForCreateDto)
        {
            var ValidationRequest = bookForCreateValidator.Validate(bookForCreateDto);
            if (!ValidationRequest.IsValid)
            {
                return Result.Failure("Book is Invalid");
            }            
            var book=new Book(
                bookForCreateDto.Isbn,
                bookForCreateDto.Name,
                bookForCreateDto.Author,
                bookForCreateDto.Place,
                bookForCreateDto.Count
            );
            await bookRepository.CreateEntityAsync(book);
            return Result.Success();
        }        
    }
}
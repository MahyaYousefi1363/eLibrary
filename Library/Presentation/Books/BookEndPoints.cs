using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using eLibrary.Library.Application.Books.Contracts;
using eLibrary.Library.Application.Books.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Library.Presentation.Books
{
    public class BookEndPoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var books = app.MapGroup("books").DisableAntiforgery().WithTags("Books");
            books.MapPost("/CreateBook", CreateBookAsync);
        }
        async Task<IResult> CreateBookAsync(
            [FromBody] BookForCreateDto bookForCreateDto,
            [FromServices] IBookManager bookManager
        )
        {
            var CreateResult = await bookManager.CreateBookAsync(bookForCreateDto);
            if (CreateResult.IsFailure)
                return Results.BadRequest(CreateResult.Error);
            else
                return Results.Ok();
        }
    }
}
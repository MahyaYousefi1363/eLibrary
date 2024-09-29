using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using eLibrary.Library.Application.Rents.Contracts;
using eLibrary.Library.Application.Rents.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Library.Presentation.Rents
{
    public class RentEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var rents = app.MapGroup("rents").DisableAntiforgery().WithTags("Rents");
            rents.MapPost("/CreateRentWithRestrictionAsync", CreateRentWithRestrictionAsync);
            rents.MapPatch("/ReturnRent/{RentId}", ReturnRent);
            rents.MapGet("/GetExpiredRentsList", GetExpiredRentsList);
        }
        async Task<IResult> CreateRentWithRestrictionAsync(
            [FromBody] RentForCreateDto rentForCreateDto,
            [FromServices] IRentManager rentManager
        )
        {
            var CreateResult = await rentManager.CreateRentAsync(rentForCreateDto);
            if (CreateResult.IsFailure)
                return Results.BadRequest(CreateResult.Error);
            else
                return Results.Ok();
        }

        async Task<IResult> ReturnRent(
            [FromRoute] Guid RentId,
            [FromServices] IRentManager rentManager
        )
        {
            var ReturnRentResult = await rentManager.ReturnRent(RentId);
            if (ReturnRentResult.IsFailure)
                return Results.BadRequest(ReturnRentResult.Error);
            else
                return TypedResults.Ok();
        }

        async Task<IResult> GetExpiredRentsList([FromServices] IRentManager rentManager)
        {
            var expiredRentsList = await rentManager.GetExpiredRentsList();
            if (expiredRentsList.IsFailure)
                return Results.BadRequest(expiredRentsList.Error);
            else
                return TypedResults.Ok();
        }
    }
}
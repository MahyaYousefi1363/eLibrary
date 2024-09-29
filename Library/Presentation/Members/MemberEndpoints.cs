using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carter;
using eLibrary.Library.Application.Members.Contracts;
using eLibrary.Library.Application.Members.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace eLibrary.Library.Presentation.Members
{
    public class MemberEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var members = app.MapGroup("members").DisableAntiforgery().WithTags("Members");
            members.MapPost("/CreateMember", CreateMemberAsync);

        }
        async Task<IResult> CreateMemberAsync(
            [FromBody] MemberForCreateDto memberForCreateDto,
            [FromServices] IMemberManager memberManager
        )
        {
            var CreateResult = await memberManager.CreateMemberAsync(memberForCreateDto);
            if (CreateResult.IsFailure)
                return Results.BadRequest(CreateResult.Error);
            else
                return Results.Ok();
        }

    }
}
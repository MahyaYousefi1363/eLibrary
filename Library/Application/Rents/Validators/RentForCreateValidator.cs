using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Application.Rents.Dtos;
using FluentValidation;

namespace eLibrary.Library.Application.Validators
{
    public class RentForCreateValidator : AbstractValidator<RentForCreateDto>
    {
        public RentForCreateValidator()
        {
            RuleFor(r=>r.MemberNationalCode).MinimumLength(10).MaximumLength(10).NotEmpty().NotNull();
            RuleFor(r=>r.BookIsbn).NotEmpty().NotNull();
            RuleFor(r=>r.RentDate).NotEmpty().NotNull();
        }
    }
}
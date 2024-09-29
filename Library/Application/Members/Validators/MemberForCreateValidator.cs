using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Application.Members.Dtos;
using FluentValidation;

namespace eLibrary.Library.Application.Members.Validators
{
    public class MemberForCreateValidator : AbstractValidator<MemberForCreateDto>
    {
        public MemberForCreateValidator()
        {
            RuleFor(m=>m.NationalCode).MinimumLength(10).MaximumLength(10).NotEmpty().NotNull();
            RuleFor(m=>m.FullName).MinimumLength(5).MaximumLength(50).NotEmpty().NotNull();
            RuleFor(m=>m.MobileNumber).MinimumLength(11).MaximumLength(11).NotEmpty().NotNull();
            RuleFor(m=>m.Address).MinimumLength(10).MaximumLength(100).NotEmpty().NotNull();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eLibrary.Library.Application.Books.Dtos;
using FluentValidation;

namespace eLibrary.Library.Application.Books
.Validators
{
    public class BookForCreateValidator : AbstractValidator<BookForCreateDto>
    {
        public BookForCreateValidator()
        {
            RuleFor(b=>b.Isbn).NotEmpty().NotNull();
            RuleFor(b=>b.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(b=>b.Author).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(b=>b.Place).NotEmpty().NotNull().MinimumLength(3).MaximumLength(10);
            RuleFor(b=>b.Count).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
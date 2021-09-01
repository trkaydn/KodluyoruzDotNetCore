using FluentValidation;
using System;

namespace WebApi.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.Title).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.GenreId).NotEmpty().GreaterThan(0);
        }
    }
}

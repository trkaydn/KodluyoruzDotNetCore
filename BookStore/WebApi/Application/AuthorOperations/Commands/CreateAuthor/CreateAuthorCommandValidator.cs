using FluentValidation;
using System;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Model.BirthDate).LessThan(DateTime.Now);
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Model.Surname).NotEmpty().MinimumLength(2);

        }
    }
}

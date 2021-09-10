﻿using FluentValidation;

namespace MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
    {
        public DeleteDirectorCommandValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);

        }
    }
}

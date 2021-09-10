using FluentValidation;

namespace MovieStore.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
    {
        public UpdateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.SurName).MinimumLength(2);
        }

    }
}

using FluentValidation;


namespace MovieStore.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {
        public CreateActorCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.SurName).MinimumLength(2);
        }
    }
}

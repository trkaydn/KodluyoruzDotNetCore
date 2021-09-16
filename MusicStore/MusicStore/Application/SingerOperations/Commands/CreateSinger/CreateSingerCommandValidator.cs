
using FluentValidation;

namespace MusicStore.Application.SingerOperations.Commands.CreateSinger
{
    public class CreateSingerCommandValidator : AbstractValidator<CreateSingerCommand>
    {
        public CreateSingerCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.SurName).MinimumLength(2);
        }
    }
}

using FluentValidation;

namespace MusicStore.Application.SingerOperations.Commands.UpdateSinger
{
    public class UpdateSingerCommandValidator : AbstractValidator<UpdateSingerCommand>
    {
        public UpdateSingerCommandValidator()
        {
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.SurName).MinimumLength(2);
        }

    }
}

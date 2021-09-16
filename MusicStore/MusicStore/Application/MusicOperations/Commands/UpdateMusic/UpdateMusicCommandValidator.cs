using FluentValidation;

namespace MusicStore.Application.MusicOperations.Commands.UpdateMusic
{
    public class UpdateMusicCommandValidator : AbstractValidator<UpdateMusicCommand>
    {
        public UpdateMusicCommandValidator()
        {
            RuleFor(x => x.MusicId).GreaterThan(0);
            RuleFor(x => x.Model.SingerId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.Price).GreaterThan(0);
        }
    }
}
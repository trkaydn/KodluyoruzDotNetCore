using FluentValidation;

namespace MusicStore.Application.MusicOperations.Commands.CreateMusic
{
    public class CreateMusicCommandValidator : AbstractValidator<CreateMusicCommand>
    {
        public CreateMusicCommandValidator()
        {
            RuleFor(x => x.Model.SingerId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Model.Price).NotEmpty().GreaterThan(0);
        }
    }
}

using FluentValidation;

namespace MusicStore.Application.MusicOperations.Commands.DeleteMusic
{
    public class DeleteMusicCommandValidator : AbstractValidator<DeleteMusicCommand>
    {
        public DeleteMusicCommandValidator()
        {
            RuleFor(x => x.MusicId).NotEmpty().GreaterThan(0);
        }
    }
}

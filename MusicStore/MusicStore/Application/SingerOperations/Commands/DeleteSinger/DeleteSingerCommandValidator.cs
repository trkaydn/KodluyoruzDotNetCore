using FluentValidation;

namespace MusicStore.Application.SingerOperations.Commands.DeleteSinger
{
    public class DeleteSingerCommandValidator : AbstractValidator<DeleteSingerCommand>
    {
        public DeleteSingerCommandValidator()
        {
            RuleFor(x => x.SingerId).GreaterThan(0);
        }
    }
}

using FluentValidation;

namespace MovieStore.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
    {
        public UpdateMovieCommandValidator()
        {
            RuleFor(x => x.MovieId).GreaterThan(0);
            RuleFor(x => x.Model.DirectorId).GreaterThan(0);
            RuleFor(x => x.Model.GenreId).GreaterThan(0);
            RuleFor(x => x.Model.Name).MinimumLength(2);
            RuleFor(x => x.Model.Price).GreaterThan(0);
        }
    }
}

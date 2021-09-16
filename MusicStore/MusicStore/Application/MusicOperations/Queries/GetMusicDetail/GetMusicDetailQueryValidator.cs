using FluentValidation;

namespace MusicStore.Application.MusicOperations.Queries.GetMusicDetail
{
    public class GetMusicDetailQueryValidator : AbstractValidator<GetMusicDetailQuery>
    {
        public GetMusicDetailQueryValidator()
        {
            RuleFor(query => query.MusicId).NotEmpty().GreaterThan(0);
        }
    }
}

using FluentValidation;

namespace MusicStore.Application.SingerOperations.Queries.GetSingerDetail
{
    public class GetSingerDetailQueryValidator : AbstractValidator<GetSingerDetailQuery>
    {
        public GetSingerDetailQueryValidator()
        {
            RuleFor(x => x.SingerId).GreaterThan(0);
        }
    }
}

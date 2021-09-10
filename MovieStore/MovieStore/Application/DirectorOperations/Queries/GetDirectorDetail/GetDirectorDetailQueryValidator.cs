using FluentValidation;

namespace MovieStore.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
    {
        public GetDirectorDetailQueryValidator()
        {
            RuleFor(x => x.DirectorId).GreaterThan(0);

        }
    }
}

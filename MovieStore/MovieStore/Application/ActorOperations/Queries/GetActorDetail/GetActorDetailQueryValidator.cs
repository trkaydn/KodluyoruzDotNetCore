using FluentValidation;

namespace MovieStore.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
    {
        public GetActorDetailQueryValidator()
        {
            RuleFor(x => x.ActorId).GreaterThan(0);
        }
    }
}

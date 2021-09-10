using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.ActorOperations.Commands.DeleteActor
{
    public class DeleteActorCommand
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteActorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var actor = _dbContext.Actors.SingleOrDefault(x => x.Id == ActorId);
            if (actor is null || actor.Status == false)
                throw new InvalidOperationException("Silinecek oyuncu bulunamadı");

            actor.Status = false;
            _dbContext.SaveChanges();
        }

    }
}

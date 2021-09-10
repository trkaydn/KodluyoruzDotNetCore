using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteDirectorCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var director = _dbContext.Directors.SingleOrDefault(x => x.Id == DirectorId);
            if (director is null || director.Status == false)
                throw new InvalidOperationException("Silinecek yönetmen bulunamadı");

            director.Status = false;
            _dbContext.SaveChanges();
        }
    }
}

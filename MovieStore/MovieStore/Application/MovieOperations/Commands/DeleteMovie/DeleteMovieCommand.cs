using AutoMapper;
using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public DeleteMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id==MovieId);
            if (movie is null || movie.Status==false)
                throw new InvalidOperationException("Silinecek film bulunamadı");

            movie.Status = false;
            _dbContext.SaveChanges();
        }

    }
}

using MovieStore.DbOperations;
using System;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public UpdateMovieModel Model { get; set; }
        private readonly IMovieStoreDbContext _dbContext;

        public UpdateMovieCommand(IMovieStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == MovieId);
            if (movie is null || movie.Status==false)
                throw new InvalidOperationException("Güncellenecek film bulunamadı.");

            movie.GenreId = Model.GenreId != default ? Model.GenreId : movie.GenreId;
            movie.DirectorId = Model.DirectorId != default ? Model.DirectorId : movie.DirectorId;
            movie.Name = Model.Name != default ? Model.Name : movie.Name;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            _dbContext.SaveChanges();

        }
    }
    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int DirectorId { get; set; }
        public double Price { get; set; }

    }
}

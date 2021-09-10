using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<MoviesViewModel> Handle()
        {
            var movieList = _dbContext.Movies.Where(x=>x.Status==true).Include(x => x.Genre).Include(x => x.Director).Include(x => x.Actors).ToList();

            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }
    }
    public class MoviesViewModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
        public double Price { get; set; }
    }
}

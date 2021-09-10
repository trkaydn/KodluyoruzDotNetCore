using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        public int MovieId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMovieDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _dbContext.Movies.Where(x=> x.Id==MovieId && x.Status==true).Include(x => x.Genre).Include(x=>x.Director).Include(x=>x.Actors).SingleOrDefault();

            if (movie is null)
            {
                throw new InvalidOperationException("Böyle bir film bulunamadı.");
            }
            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
            return vm;
        }
    }
    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public List<Actor> Actors { get; set; }
        public double Price { get; set; }
    }
}

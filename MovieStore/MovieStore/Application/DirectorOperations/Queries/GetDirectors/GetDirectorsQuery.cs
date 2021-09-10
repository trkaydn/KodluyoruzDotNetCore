using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Queries.GetDirectors
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorsQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            var directorList = _dbContext.Directors.Where(x => x.Status == true).ToList();

            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directorList);
            return vm;
        }
    }
    public class DirectorsViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Movie> DirectedMovies { get; set; }
    }
}

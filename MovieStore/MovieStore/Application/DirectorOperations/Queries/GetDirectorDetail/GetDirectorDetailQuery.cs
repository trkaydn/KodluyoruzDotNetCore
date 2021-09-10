using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.DirectorOperations.Queries.GetDirectorDetail
{
    public class GetDirectorDetailQuery
    {
        public int DirectorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDirectorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public DirectorDetailViewModel Handle()
        {
            var director = _dbContext.Directors.Where(x => x.Id == DirectorId && x.Status == true).SingleOrDefault();

            if (director is null)
            {
                throw new InvalidOperationException("Böyle bir yönetmen bulunamadı.");
            }
            DirectorDetailViewModel vm = _mapper.Map<DirectorDetailViewModel>(director);
            return vm;
        }
    }
    public class DirectorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Movie> DirectedMovies { get; set; }
    }
}

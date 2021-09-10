using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.DbOperations;
using MovieStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieStore.Application.ActorOperations.Queries.GetActorDetail
{
    public class GetActorDetailQuery
    {
        public int ActorId { get; set; }
        private readonly IMovieStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActorDetailQuery(IMovieStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ActorDetailViewModel Handle()
        {
            var actor = _dbContext.Actors.Where(x=>x.Id==ActorId && x.Status==true).Include(x => x.StarringMovies).SingleOrDefault();

            if (actor is null)
            {
                throw new InvalidOperationException("Böyle bir oyuncu bulunamadı.");
            }
            ActorDetailViewModel vm = _mapper.Map<ActorDetailViewModel>(actor);
            return vm;
        }
    }
    public class ActorDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public List<Movie> StarringMovies { get; set; }
    }
}


using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Application.SingerOperations.Queries.GetSingers
{
    public class GetSingersQuery
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSingersQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<SingersViewModel> Handle()
        {
            var singerList = _dbContext.Singers.Where(x => x.Status == true).Include(x => x.Songs).ToList();

            List<SingersViewModel> vm = _mapper.Map<List<SingersViewModel>>(singerList);
            return vm;
        }
    }
    public class SingersViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int SongCount { get; set; }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.DbOperations;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Application.MusicOperations.Queries.GetMusics
{
    public class GetMusicsQuery
    {
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMusicsQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public List<MusicsViewModel> Handle()
        {
            var musicList = _dbContext.Musics.Where(x => x.Status == true).Include(x => x.Genre).Include(x => x.Singer).ToList();
            List<MusicsViewModel> vm = _mapper.Map<List<MusicsViewModel>>(musicList);
            return vm;
        }
    }
    public class MusicsViewModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Singer { get; set; }
        public double Price { get; set; }
    }
}

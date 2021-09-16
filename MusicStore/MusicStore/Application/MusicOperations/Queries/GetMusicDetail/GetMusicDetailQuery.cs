using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.MusicOperations.Queries.GetMusicDetail
{
    public class GetMusicDetailQuery
    {
        public int MusicId { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMusicDetailQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public MusicDetailViewModel Handle()
        {
            var music = _dbContext.Musics.Where(x => x.Id == MusicId && x.Status == true).Include(x => x.Genre).Include(x => x.Singer).SingleOrDefault();

            if (music is null)
            {
                throw new InvalidOperationException("Böyle bir şarkı bulunamadı.");
            }
            MusicDetailViewModel vm = _mapper.Map<MusicDetailViewModel>(music);
            return vm;
        }
    }
    public class MusicDetailViewModel
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Singer { get; set; }
        public double Price { get; set; }
    }
}

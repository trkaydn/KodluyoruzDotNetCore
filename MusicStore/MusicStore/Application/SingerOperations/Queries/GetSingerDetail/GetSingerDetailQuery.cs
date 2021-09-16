using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Application.SingerOperations.Queries.GetSingerDetail
{
    public class GetSingerDetailQuery
    {
        public int SingerId { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSingerDetailQuery(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public SingerDetailViewModel Handle()
        {
            var singer = _dbContext.Singers.Where(x => x.Id == SingerId && x.Status == true).Include(x => x.Songs).SingleOrDefault();

            if (singer is null)
            {
                throw new InvalidOperationException("Böyle bir şarkıcı bulunamadı.");
            }
            SingerDetailViewModel vm = _mapper.Map<SingerDetailViewModel>(singer);
            return vm;
        }
    }
    public class SingerDetailViewModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public int SongCount { get; set; }
    }
}

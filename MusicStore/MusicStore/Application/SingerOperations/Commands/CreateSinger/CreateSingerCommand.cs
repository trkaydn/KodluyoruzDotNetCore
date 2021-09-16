using AutoMapper;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System;
using System.Linq;

namespace MusicStore.Application.SingerOperations.Commands.CreateSinger
{
    public class CreateSingerCommand
    {
        public CreateSingerModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateSingerCommand(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var singer = _dbContext.Singers.SingleOrDefault(x => x.Name == Model.Name && x.SurName == Model.SurName);

            if (singer != null)
                throw new InvalidOperationException("Şarkıcı zaten mevcut.");

            singer = _mapper.Map<Singer>(Model);

            _dbContext.Singers.Add(singer);
            _dbContext.SaveChanges();
        }

    }
    public class CreateSingerModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}

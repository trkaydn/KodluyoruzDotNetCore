using AutoMapper;
using MusicStore.DbOperations;
using MusicStore.Entities;
using System;
using System.Linq;

namespace MusicStore.Application.MusicOperations.Commands.CreateMusic
{
    public class CreateMusicCommand
    {
        public CreateMusicModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateMusicCommand(IMusicStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var music = _dbContext.Musics.SingleOrDefault(x => x.Name == Model.Name);

            if (music != null)
                throw new InvalidOperationException("Şarkı zaten mevcut.");

            music = _mapper.Map<Music>(Model);

            _dbContext.Musics.Add(music);
            _dbContext.SaveChanges();
        }
    }
    public class CreateMusicModel
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int SingerId { get; set; }
        public double Price { get; set; }

    }
}

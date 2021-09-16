using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.MusicOperations.Commands.UpdateMusic
{
    public class UpdateMusicCommand
    {
        public int MusicId { get; set; }
        public UpdateMusicModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;

        public UpdateMusicCommand(IMusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var music = _dbContext.Musics.SingleOrDefault(x => x.Id == MusicId);
            if (music is null || music.Status == false)
                throw new InvalidOperationException("Güncellenecek şarkı bulunamadı.");

            music.GenreId = Model.GenreId != default ? Model.GenreId : music.GenreId;
            music.SingerId = Model.SingerId != default ? Model.SingerId : music.SingerId;
            music.Name = Model.Name != default ? Model.Name : music.Name;
            music.Price = Model.Price != default ? Model.Price : music.Price;
            _dbContext.SaveChanges();

        }
    }
    public class UpdateMusicModel
    {
        public string Name { get; set; }
        public int GenreId { get; set; }
        public int SingerId { get; set; }
        public double Price { get; set; }
    }
}

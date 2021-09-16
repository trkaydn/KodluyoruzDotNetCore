using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.MusicOperations.Commands.DeleteMusic
{
    public class DeleteMusicCommand
    {
        public int MusicId { get; set; }
        private readonly IMusicStoreDbContext _dbContext;

        public DeleteMusicCommand(IMusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var Music = _dbContext.Musics.SingleOrDefault(x => x.Id == MusicId);
            if (Music is null || Music.Status == false)
                throw new InvalidOperationException("Silinecek şarkı bulunamadı");

            Music.Status = false;
            _dbContext.SaveChanges();
        }

    }
}
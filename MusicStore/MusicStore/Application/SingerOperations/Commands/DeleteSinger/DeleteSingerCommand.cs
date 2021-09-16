using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.SingerOperations.Commands.DeleteSinger
{
    public class DeleteSingerCommand
    {
        public int SingerId { get; set; }
        private readonly IMusicStoreDbContext _dbContext;

        public DeleteSingerCommand(IMusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            var singer = _dbContext.Singers.SingleOrDefault(x => x.Id == SingerId);
            if (singer is null || singer.Status == false)
                throw new InvalidOperationException("Silinecek şarkıcı bulunamadı");

            singer.Status = false;
            _dbContext.SaveChanges();
        }
    }
}

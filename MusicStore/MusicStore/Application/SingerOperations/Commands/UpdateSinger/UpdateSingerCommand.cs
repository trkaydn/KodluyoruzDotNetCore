using MusicStore.DbOperations;
using System;
using System.Linq;

namespace MusicStore.Application.SingerOperations.Commands.UpdateSinger
{
    public class UpdateSingerCommand
    {
        public int SingerId { get; set; }
        public UpdateSingerModel Model { get; set; }
        private readonly IMusicStoreDbContext _dbContext;

        public UpdateSingerCommand(IMusicStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var singer = _dbContext.Singers.SingleOrDefault(x => x.Id == SingerId);
            if (singer is null || singer.Status == false)
                throw new InvalidOperationException("Güncellenecek şarkıcı bulunamadı.");

            singer.Name = Model.Name != default ? Model.Name : singer.Name;
            singer.SurName = Model.SurName != default ? Model.SurName : singer.SurName;
            _dbContext.SaveChanges();
        }
    }
    public class UpdateSingerModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
    }
}

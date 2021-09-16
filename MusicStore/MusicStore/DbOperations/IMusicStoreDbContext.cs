using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.DbOperations
{
    public interface IMusicStoreDbContext
    {
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }

        int SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore;
using MusicStore.Entities;

namespace MusicStore.DbOperations
{
    public class MusicStoreDbContext : DbContext, IMusicStoreDbContext
    {
        public MusicStoreDbContext(DbContextOptions<MusicStoreDbContext> options) : base(options)
        {

        }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Order> Orders { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicStore.Common;
using MusicStore.DbOperations;
namespace MusicStore.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public MusicStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<MusicStoreDbContext>().UseInMemoryDatabase(databaseName: "MusicStoreTestDB").Options;
            Context = new MusicStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddSingers();
            Context.AddCustomers();
            Context.AddGenres();
            Context.AddMusics();
            Context.AddOrders();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}

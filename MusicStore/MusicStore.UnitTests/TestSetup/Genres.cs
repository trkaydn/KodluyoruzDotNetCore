using MusicStore.DbOperations;
using MusicStore.Entities;

namespace MusicStore.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MusicStoreDbContext context)
        {
            context.Genres.AddRange(
                   new Genre { Name = "Rap" },
                   new Genre { Name = "Rock" },
                   new Genre { Name = "Folk" }
                   );
        }
    }
}

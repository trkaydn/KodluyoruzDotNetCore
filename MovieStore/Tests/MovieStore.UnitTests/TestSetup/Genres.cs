using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenres(this MovieStoreDbContext context)
        {
            context.Genres.AddRange(
                   new Genre { Name = "Action" },
                   new Genre { Name = "Strategy" },
                   new Genre { Name = "Comedy" }
                   );
        }
    }
}

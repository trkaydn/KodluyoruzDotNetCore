using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Movies
    {
        public static void AddMovies(this MovieStoreDbContext context)
        {
            context.Movies.AddRange(
                   new Movie { Name = "Sherlock Holmes", DirectorId = 1, GenreId = 1, Price = 12.5 },
                   new Movie { Name = "Fast & Furious 8", DirectorId = 2, GenreId = 2, Price = 10.5 },
                   new Movie { Name = "Titanic", DirectorId = 3, GenreId = 3, Price = 6.5 }
                   );
        }
    }
}

using MusicStore.DbOperations;
using MusicStore.Entities;

namespace MusicStore.UnitTests.TestSetup
{
    public static class Musics
    {
        public static void AddMusics(this MusicStoreDbContext context)
        {
            context.Musics.AddRange(
                    new Music { Name = "Mekanın Sahibi", SingerId = 1, GenreId = 1, Price = 10 },
                    new Music { Name = "Tamirci Çırağı", SingerId = 3, GenreId = 3, Price = 12.5 },
                    new Music { Name = "Yürek", SingerId = 2, GenreId = 2, Price = 10.5 }
                    );
        }
    }
}

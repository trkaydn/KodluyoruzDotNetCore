using MusicStore.DbOperations;
using MusicStore.Entities;

namespace MusicStore.UnitTests.TestSetup
{
    public static class Singers
    {
        public static void AddSingers(this MusicStoreDbContext context)
        {
            context.Singers.AddRange(
                     new Singer { Name = "Norm", SurName = "Ender" },
                    new Singer { Name = "Duman", SurName = "Grup" },
                    new Singer { Name = "Cem", SurName = "Karaca" }
                  );
        }
    }
}

using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Actors
    {
        public static void AddActors(this MovieStoreDbContext context)
        {
            context.Actors.AddRange(
                  new Actor { Name = "Benedict", SurName = "Cumberbatch" },
                  new Actor { Name = "Robert", SurName = "Downey" },
                  new Actor { Name = "Paul", SurName = "Walker" }
                  );
        }
    }
}

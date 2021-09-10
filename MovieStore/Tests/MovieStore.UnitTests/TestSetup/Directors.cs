using MovieStore.DbOperations;
using MovieStore.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Directors
    {
        public static void AddDirectors(this MovieStoreDbContext context)
        {
            context.Customers.AddRange(
                   new Customer { Name = "Tarık", SurName = "Aydın", Email = "tarikayydin1846@gmail.com", Password = "12345" },
                   new Customer { Name = "Faruk", SurName = "Aydın,", Email = "faruk@hotmail.com", Password = "12345" },
                   new Customer { Name = "Ali", SurName = "Veli", Email = "ali@hotmail.com", Password = "12345" }
                   );
        }
    }
}
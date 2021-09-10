using MovieStore.DbOperations;
using MovieStore.Entities;
using System;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.Orders.AddRange(
                    new Order { CustomerId = 1, MovieId = 1, OrderDate = new DateTime(1990, 05, 20), Price = 12.5 },
                    new Order { CustomerId = 2, MovieId = 2, OrderDate = new DateTime(1980, 02, 10), Price = 10.5 },
                    new Order { CustomerId = 3, MovieId = 3, OrderDate = new DateTime(2000, 10, 12), Price = 6.5 }
                        );
        }

    }
}

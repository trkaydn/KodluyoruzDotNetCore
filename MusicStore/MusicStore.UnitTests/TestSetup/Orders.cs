using MusicStore.DbOperations;
using MusicStore.Entities;
using System;

namespace MusicStore.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MusicStoreDbContext context)
        {
            context.Orders.AddRange(
                      new Order { CustomerId = 1, MusicId = 1, OrderDate = new DateTime(1990, 05, 20), Price = 10 },
                      new Order { CustomerId = 2, MusicId = 2, OrderDate = new DateTime(1980, 02, 10), Price = 12.5 },
                      new Order { CustomerId = 3, MusicId = 3, OrderDate = new DateTime(2000, 10, 12), Price = 10.5 }
                          );
        }

    }
}

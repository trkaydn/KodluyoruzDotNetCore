﻿using MusicStore.DbOperations;
using MusicStore.Entities;

namespace MusicStore.UnitTests.TestSetup
{
    public static class Customers
    {
        public static void AddCustomers(this MusicStoreDbContext context)
        {
            context.Customers.AddRange(
                   new Customer { Name = "Tarık", SurName = "Aydın", Email = "tarikayydin1846@gmail.com", Password = "12345" },
                   new Customer { Name = "Faruk", SurName = "Aydın,", Email = "faruk@hotmail.com", Password = "12345" },
                   new Customer { Name = "Ali", SurName = "Veli", Email = "ali@hotmail.com", Password = "12345" }
                   );
        }
    }
}

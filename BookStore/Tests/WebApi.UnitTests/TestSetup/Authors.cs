using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Authors.AddRange(
               new Author { Name = "Tarık", Surname = "Aydın", BirthDate = new DateTime(2001, 03, 25) },
               new Author { Name = "Ali", Surname = "Veli", BirthDate = new DateTime(2010, 05, 23) },
               new Author { Name = "Ayşe", Surname = "Aksoy", BirthDate = new DateTime(2000, 03, 05) });
        }
    }
}

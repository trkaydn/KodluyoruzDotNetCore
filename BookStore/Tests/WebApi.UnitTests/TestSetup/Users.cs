using System;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Users
    {
        public static void AddUsers(this BookStoreDbContext context)
        {
            context.Users.AddRange(
               new User { Name = "Tarık", SurName = "Aydın", Email = "tarikayydin1846@gmail.com", Password = "12345" },
               new User { Name = "Ali", SurName = "Veli", Email = "deneme@hotmail.com", Password = "12345" },
               new User { Name = "Ayşe", SurName = "Aksoy", Email = "deneme2@hotmail.com", Password = "12345" });
        }
    }
}

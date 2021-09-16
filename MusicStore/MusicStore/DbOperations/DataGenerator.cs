using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicStore.Entities;
using System;
using System.Linq;

namespace MusicStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MusicStoreDbContext>>()))
            {
                if (context.Musics.Any())
                    return;

                context.Singers.AddRange(
                    new Singer { Name = "Norm", SurName = "Ender" },
                    new Singer { Name = "Duman", SurName = "Grup" },
                    new Singer { Name = "Cem", SurName = "Karaca" }
                    );
                context.Customers.AddRange(
                    new Customer { Name = "Tarık", SurName = "Aydın", Email = "tarikayydin1846@gmail.com", Password = "12345" },
                    new Customer { Name = "Faruk", SurName = "Aydın,", Email = "faruk@hotmail.com", Password = "12345" },
                    new Customer { Name = "Ali", SurName = "Veli", Email = "ali@hotmail.com", Password = "12345" }
                    );
                context.Genres.AddRange(
                    new Genre { Name = "Rap" },
                    new Genre { Name = "Rock" },
                    new Genre { Name = "Folk" }
                    );
                context.Musics.AddRange(
                    new Music { Name = "Mekanın Sahibi", SingerId = 1, GenreId = 1, Price = 10 },
                    new Music { Name = "Tamirci Çırağı", SingerId = 3, GenreId = 3, Price = 12.5 },
                    new Music { Name = "Yürek", SingerId = 2, GenreId = 2, Price = 10.5 }
                    );
                context.Orders.AddRange(
                    new Order { CustomerId = 1, MusicId = 1, OrderDate = new DateTime(1990, 05, 20), Price = 10 },
                    new Order { CustomerId = 2, MusicId = 2, OrderDate = new DateTime(1980, 02, 10), Price = 12.5 },
                    new Order { CustomerId = 3, MusicId = 3, OrderDate = new DateTime(2000, 10, 12), Price = 10.5 }
                        );

                context.SaveChanges();

            }
        }
    }
}

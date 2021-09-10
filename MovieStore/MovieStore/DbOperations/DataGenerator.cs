using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieStore.Entities;
using System;
using System.Linq;

namespace MovieStore.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                    return;

                context.Actors.AddRange(
                    new Actor { Name = "Benedict", SurName = "Cumberbatch" },
                    new Actor { Name = "Robert", SurName = "Downey" },
                    new Actor { Name = "Paul", SurName = "Walker" }
                    );
                context.Customers.AddRange(
                    new Customer { Name = "Tarık", SurName = "Aydın", Email = "tarikayydin1846@gmail.com", Password = "12345" },
                    new Customer { Name = "Faruk", SurName = "Aydın,", Email = "faruk@hotmail.com", Password = "12345" },
                    new Customer { Name = "Ali", SurName = "Veli", Email = "ali@hotmail.com", Password = "12345" }
                    );
                context.Directors.AddRange(
                    new Director { Name = "Ahmet", SurName = "Akar" },
                    new Director { Name = "Ayşe", SurName = "Kara" },
                    new Director { Name = "Mehmet", SurName = "Kaya" }
                    );
                context.Genres.AddRange(
                    new Genre { Name = "Action" },
                    new Genre { Name = "Strategy" },
                    new Genre { Name = "Comedy" }
                    );
                context.Movies.AddRange(
                    new Movie { Name = "Sherlock Holmes", DirectorId = 1, GenreId = 1, Price = 12.5 },
                    new Movie { Name = "Fast & Furious 8", DirectorId = 2, GenreId = 2, Price = 10.5 },
                    new Movie { Name = "Titanic", DirectorId = 3, GenreId = 3, Price = 6.5 }
                    );
                context.Orders.AddRange(
                    new Order { CustomerId = 1, MovieId = 1, OrderDate = new DateTime(1990, 05, 20), Price = 12.5 },
                    new Order { CustomerId = 2, MovieId = 2, OrderDate = new DateTime(1980, 02, 10), Price = 10.5 },
                    new Order { CustomerId = 3, MovieId = 3, OrderDate = new DateTime(2000, 10, 12), Price = 6.5 }
                        );

                context.SaveChanges();

            }

        }
    }
}



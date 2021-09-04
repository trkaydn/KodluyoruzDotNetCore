using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                    return;

             context.Authors.AddRange(
               new Author
               {
                   Name = "Tarık",
                   Surname = "Aydın",
                   BirthDate = new DateTime(2001, 03, 25),

               },
               new Author
               {
                   Name = "Ali",
                   Surname = "Veli",
                   BirthDate = new DateTime(2010, 05, 23),
               },
               new Author
               {
                   Name = "Ayşe",
                   Surname = "Aksoy",
                   BirthDate = new DateTime(2000, 03, 05),
               });


                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personel Growth"
                    },
                    new Genre
                    {
                        Name = "Science Fiction"
                    },
                    new Genre
                    {
                        Name = "Romance"
                    });

                context.Books.AddRange(

                    new Book
                    {
                        //Id = 1,
                        Title = "Lean Startup",
                        GenreId = 1, //Personel Growth
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12),
                        AuthorId = 1
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Herland",
                        GenreId = 2, //Science Fiction
                        PageCount = 250,
                        PublishDate = new DateTime(2010, 05, 23),
                        AuthorId = 2
                    },
                    new Book
                    {
                        //Id = 3,
                        Title = "Dune",
                        GenreId = 2, //Science Fiction
                        PageCount = 240,
                        PublishDate = new DateTime(2001, 05, 23),
                        AuthorId = 3
                    });

 
                context.SaveChanges();
            }
        }
    }
}

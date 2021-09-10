using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual List<Movie> PurchasedMovies { get; set; }
        public virtual List<Genre> FavoriteGenres { get; set; }
        public bool Status { get; set; } = true;
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }

    }
}

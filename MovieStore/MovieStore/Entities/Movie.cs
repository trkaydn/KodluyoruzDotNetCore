using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int DirectorId { get; set; }
        public virtual Director Director { get; set; }
        public virtual List<Actor> Actors { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; } = true;

    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Entities
{
    public class Music
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public int SingerId { get; set; }
        public virtual Singer Singer { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; } = true;
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Entities
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Music> Musics { get; set; }
    }
}

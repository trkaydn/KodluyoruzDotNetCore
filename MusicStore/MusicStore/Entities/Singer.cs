using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Entities
{
    public class Singer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual List<Music> Songs { get; set; }
        public bool Status { get; set; } = true;
    }
}

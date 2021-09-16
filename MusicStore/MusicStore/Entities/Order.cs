using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int MusicId { get; set; }
        public virtual Music Music { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieStore.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }

    }
}

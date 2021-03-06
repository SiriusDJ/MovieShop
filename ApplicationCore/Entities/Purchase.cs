using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("Purchase")]
    public class Purchase
    {
        public int Id { get; set; } 

        [Required]
        public int UserId { get; set; }

        [Required]
        public Guid PurchaseNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime PurchaseDateTime { get; set; }

        public int MovieId { get; set; }

        public Movie Movie { get; set; }
        
        public User User { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MINICORE.Models
{
    public class Seller
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MINICORE.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SellerId { get; set; } 

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }
    }
}
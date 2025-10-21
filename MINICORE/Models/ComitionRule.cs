using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MINICORE.Models
{
    public class ComitionRule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal MinimumAmount { get; set; }

        [Required]
        [Column(TypeName = "decimal(5,2)")]
        public decimal CommissionPercentage { get; set; }
    }
}
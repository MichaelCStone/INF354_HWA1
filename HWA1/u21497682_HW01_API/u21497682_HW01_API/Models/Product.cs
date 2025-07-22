using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace u21497682_HW01_API.Models
{
    public class Product
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }

        [Required]
        public string Product_Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(250)]
        public string Product_Description { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public double Product_Price { get; set; }
    }
}

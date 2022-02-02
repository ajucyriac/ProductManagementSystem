using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Api.Data.Models
{
    [Table(name: "Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Column(TypeName = "varchar(200)")]
        [Required]
        public string ProductName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string ProductCode { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime PackedDate { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime ExpiryDate { get; set; }

        [Column(TypeName = "integer")]
        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "decimal")]
        [Required]
        public decimal UnitPrice { get; set; }

    }
}

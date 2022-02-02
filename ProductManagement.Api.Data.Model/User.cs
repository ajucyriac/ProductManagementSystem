using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Api.Data.Models
{
    [Table(name: "User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Email { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Password { get; set; }


        [Column(TypeName = "datetime")]
        [Required]
        public DateTime CreateDate { get; set; }

    }
}
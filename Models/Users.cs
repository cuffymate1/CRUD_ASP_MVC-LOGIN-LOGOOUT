using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
    }
}

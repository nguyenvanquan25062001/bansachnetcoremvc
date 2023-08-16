using System.ComponentModel.DataAnnotations;

namespace banhang.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string role { get; set; }
    }
}

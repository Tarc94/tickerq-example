using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataExample.Entities
{
    public class Users
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(100)] public string Name { get; set; }
        [Required] public string Email { get; set; }
        public List<Posts> Posts { get; set; }
        public List<Comments> Comments { get; set; }
    }
}

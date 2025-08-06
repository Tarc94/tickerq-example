using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataExample.Entities
{
    public class Comments
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(500)] public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Users User { get; set; }
        public Posts Post { get; set; }
    }
}

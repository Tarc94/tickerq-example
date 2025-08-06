using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataExample.Entities
{
    public class Tags
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(50)] public string Name { get; set; }
        public List<PostTags> PostTags { get; set; }
    }
}

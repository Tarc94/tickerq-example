using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataExample.Entities
{
    public class Posts
    {
        [Key] public int Id { get; set; }
        [Required][MaxLength(200)] public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public List<Comments> Comments { get; set; }
        public List<PostTags> PostTags { get; set; }
    }
}

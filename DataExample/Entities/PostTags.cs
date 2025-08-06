namespace DataExample.Entities
{
    public class PostTags
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public Posts Post { get; set; }
        public Tags Tag { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace CameronTubeAPI.Models
{
    public class Snippet
    {
        [Key]
        public int? Id { get; set; }
        public DateTime? PublishedAt { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ThumbnailUrl { get; set; }


    }
}
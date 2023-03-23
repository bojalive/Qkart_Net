using CameronTubeAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameronTubeAPI.DTO
{
    public class VideoDTO
    {
        public Guid Id { get; set; }
        public string? Kind { get; set; }
        public string? Etag { get; set; }

        public string? ChannelTitle { get; set; }

        public string Title { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public List<string>? Tags { get; set; }

        public string Url { get; set; }

        public List<Statistics> Statistics { get; set; } = new List<Statistics>();
    }
}

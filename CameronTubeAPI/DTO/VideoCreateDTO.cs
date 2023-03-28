using CameronTubeAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameronTubeAPI.DTO
{
    public class VideoCreateDTO
    {

        public string? Kind { get; set; }
        public string? Etag { get; set; }

        public string? ChannelTitle { get; set; }

        public int CategoryId { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public List<string>? Tags { get; set; }

        public string? Name { get; set; }

        public List<Statistics> Statistics { get; set; } = new List<Statistics>();

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameronTubeAPI.Models
{
    public class Video
    {
        [Key]
        public Guid Id { get; set; }
        public string? Kind { get; set; }
        public string? Etag { get; set; }

        public string? ChannelTitle { get; set; }
        public string? Title { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public List<string>? Tags { get; set; }

        public string Name { get; set; }
    }
}

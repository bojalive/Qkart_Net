using System.ComponentModel.DataAnnotations;

namespace CameronTubeAPI.Models
{
    public class Statistics
    {
        [Key]
        public int Id { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int FavoriteCount { get; set; }
        public int CommentCount { get; set; }
    }
}
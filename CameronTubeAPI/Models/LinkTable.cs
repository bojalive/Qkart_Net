using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CameronTubeAPI.Models
{
    public class LinkTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }

        [ForeignKey("Video")]
        public Guid VideoId { get; set; }

        [ForeignKey("Snippet")]
        public int SnippetId { get; set; }

        [ForeignKey("Statistics")]
        public int StatisticsID { get; set; }
    }
}

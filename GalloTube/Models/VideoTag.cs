using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalloTube.Models;
[Table("VideoTag")]
public class VideoTag
{
    [Key, Column(Order = 1)]
    public int videoId { get; set; }
    [ForeignKey("MovieId")]
    public Vídeo video{ get; set; }

    [Key, Column(Order = 2)]
    public byte TagId { get; set; }
    [ForeignKey("tagId")]
    public Tag tag{ get; set; }
}

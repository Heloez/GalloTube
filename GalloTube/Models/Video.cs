using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace GalloTube.Models;

[Table("Video")]
public class Video
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "O Título é obrigatório")]
    [StringLength(100, ErrorMessage = "O Título deve possuir no máximo 100 caracteres")]
    public string Title { get; set; }

    [Display(Name = "Título Original")]
    [Required(ErrorMessage = "O Título Original é obrigatório")]
    [StringLength(100, ErrorMessage = "O Título Original deve possuir no máximo 100 caracteres")]
    public string OriginalTitle { get; set; }

    [Display(Name = "Descrição")]
    [Required(ErrorMessage = "A descrição é obrigatória")]
    [StringLength(8000, ErrorMessage = "A descrição deve possuir no máximo 5000 caracteres")]
    public string Description { get; set; }

    [Column(TypeName = "Data")]
    [Display(Name = "Data de envio")]
    [Required(ErrorMessage = "A Data de Envio é obrigatório")]
    public Int16 UploadDate { get; set; }

    [Display(Name = "Duração (em minutos)")]
    [Required(ErrorMessage = "A Duração é obrigatória")]
    public Int16 Duration { get; set; }

    [StringLength(200)]
    [Display(Name = "Foto")]
    public string Thumbnail { get; set; }

    [NotMapped]
    [Display(Name = "Duração")]
    public string HourDuration { get {
        return TimeSpan.FromMinutes(Duration) .ToString(@"%h'h 'mm'min'");
    }}

    public ICollection<VideoTag> Genres { get; set; }
}

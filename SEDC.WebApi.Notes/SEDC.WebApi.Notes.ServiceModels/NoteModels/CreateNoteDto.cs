using System.ComponentModel.DataAnnotations;

namespace SEDC.WebApi.Notes.ServiceModels.NoteModels
{
    public class CreateNoteDto
    {
        [Required]
        [MaxLength(1000)]
        public string Text { get; set; }
        [Required]
        [MaxLength(20)]
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }
    }
}

using SEDC.WebApi.Notes.ServiceModels.Enum;

namespace SEDC.WebApi.Notes.ServiceModels.NoteModels
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }

    }
}

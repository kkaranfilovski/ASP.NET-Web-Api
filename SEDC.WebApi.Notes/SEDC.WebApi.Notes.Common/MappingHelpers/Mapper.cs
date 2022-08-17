using SEDC.WebApi.Notes.DataModels.Models;
using SEDC.WebApi.Notes.ServiceModels.Enum;
using SEDC.WebApi.Notes.ServiceModels.NoteModels;

namespace SEDC.WebApi.Notes.Common.MappingHelpers
{
    public static class Mapper
    {
        public static NoteDto Map(this Note note)
        {
            return new NoteDto
            {
                Id = note.Id,
                Color = note.Color,
                Tag = (TagType)note.Tag,
                Text = note.Text,
                UserId = note.UserId
            };
        }
    }
}

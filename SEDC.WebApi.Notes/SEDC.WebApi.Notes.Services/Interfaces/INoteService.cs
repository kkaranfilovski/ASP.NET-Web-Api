using SEDC.WebApi.Notes.DataAccess;
using SEDC.WebApi.Notes.ServiceModels.NoteModels;

namespace SEDC.WebApi.Notes.Services.Interfaces
{
    public interface INoteService
    {
        IEnumerable<NoteDto> GetUserNotes(int userId);
        NoteDto GetNote(int id, int userId);
    }
}

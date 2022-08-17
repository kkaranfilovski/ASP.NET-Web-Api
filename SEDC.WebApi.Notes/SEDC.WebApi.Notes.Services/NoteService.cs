using SEDC.WebApi.Notes.Common.MappingHelpers;
using SEDC.WebApi.Notes.DataAccess;
using SEDC.WebApi.Notes.DataModels.Models;
using SEDC.WebApi.Notes.ServiceModels.NoteModels;
using SEDC.WebApi.Notes.Services.Interfaces;

namespace SEDC.WebApi.Notes.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public NoteDto GetNote(int id, int userId)
        {
            var note = _noteRepository.FilterBy(x => x.Id == id && x.UserId == userId).FirstOrDefault();
            
            if (note == null)
            {
                throw new Exception("Note not found");
            }

            return note.Map();
        }

        public IEnumerable<NoteDto> GetUserNotes(int userId)
        {
            var notes = _noteRepository.FilterBy(x => x.UserId == userId).Select(x => x.Map());
            return notes;
        }
    }
}

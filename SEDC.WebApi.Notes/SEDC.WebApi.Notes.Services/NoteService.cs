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
        private readonly IRepository<User> _userRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public string AddNote(CreateNoteDto note)
        {
            var user = _userRepository.GetById(note.UserId);

            if(user == null)
            {
                throw new Exception("User not found");
            }

            var newNote = new Note
            {
                Text = note.Text,
                UserId = note.UserId,
                Color = note.Color,
                Tag = note.Tag
            };

            _noteRepository.Insert(newNote);
            var url = "";
            return url;
        }

        public void DeleteNote(int id, int userId)
        {
            var note = _noteRepository.FilterBy(x => x.Id == id && x.UserId == userId).FirstOrDefault();

            if(note == null)
            {
                throw new Exception("Note not found");
            }

            _noteRepository.Delete(note);
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

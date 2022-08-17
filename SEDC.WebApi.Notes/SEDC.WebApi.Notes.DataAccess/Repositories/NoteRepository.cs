using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DataAccess.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        public int Delete(Note entity)
        {
            var count = InMemoryDB.Notes.Count;
            InMemoryDB.Notes.Remove(entity);
            return count - InMemoryDB.Notes.Count;
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            var filtered = InMemoryDB.Notes.Where(filter);
            return filtered;
        }

        public IEnumerable<Note> GetAll()
        {
            return InMemoryDB.Notes.ToList();
        }

        public Note GetById(int id)
        {
            return InMemoryDB.Notes.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Note entity)
        {
            var count = InMemoryDB.Notes.Count;
            InMemoryDB.Notes.Add(entity);
            return InMemoryDB.Notes.Count - count ;
        }

        public int Update(Note entity)
        {
            throw new NotImplementedException();
        }
    }
}

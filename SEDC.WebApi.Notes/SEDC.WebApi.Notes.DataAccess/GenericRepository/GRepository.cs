using SEDC.WebApi.Notes.DataModels;

namespace SEDC.WebApi.Notes.DataAccess.GenericRepository
{
    public class GRepository<T> : IRepository<T> where T : BaseEntity
    {
        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FilterBy(Func<T, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

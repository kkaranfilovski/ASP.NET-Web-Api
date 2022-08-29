using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SEDC.WebApi.Notes.Common.Models;
using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DataAccess.Repositories
{
    public class NoteDapperRepository : IRepository<Note>
    {

        private readonly string _connectionString;

        public NoteDapperRepository(IOptions<AppSettings> options)
        {
            _connectionString = options.Value.ConnString;
        }

        public IEnumerable<Note> GetAll()
        {
            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "select * from dbo.Note";
                connection.Open();
                var notes = connection.Query<Note>(query);
                return notes;
            }
        }

        public Note GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = "select * from dbo.Note where Id = @id";
                connection.Open();
                var note = connection.Query<Note>(query, new {id});
                return note.FirstOrDefault();
            }
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            using(SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "select * from dbo.Note";
                sqlConnection.Open();

                var notes = sqlConnection.Query<Note>(query).Where(filter);
                return notes;
            }
        }

        public int Insert(Note entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = @"insert into dbo.Note([Text], [Color], [Tag], [UserId])
                             values(@text, @color, @tag, @userId)";

                connection.Open();
                connection.Query<Note>(query, new 
                {
                    text = entity.Text,
                    color = entity.Color,
                    tag = entity.Tag,
                    UserId = entity.UserId
                });

                return entity.Id;
            }
        }

        public int Update(Note entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var query = @"update dbo.Note
                             SET
                             Text = @text
                             Color = @color
                             Tag = @tag
                             UserId = @userId
                             WHERE Id = @id";

                connection.Open();
                connection.Query<Note>(query, new
                {
                    text = entity.Text,
                    color = entity.Color,
                    tag = entity.Tag,
                    UserId = entity.UserId
                });

                return entity.Id;
            }
        }

        public int Delete(Note entity)
        {
            using (SqlConnection connection = new(_connectionString))
            {
                var sqlQuery = @"delete from dbo.Note where Id = @id";

                connection.Open();
                connection.Query(sqlQuery, new { id = entity.Id });

                return entity.Id;
            }
        }
    }
}

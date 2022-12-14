using Dapper;
using SEDC.WebApi.Class08.AdoNET.Models;
using System.Data.SqlClient;

namespace SEDC.WebApi.Class08.AdoNET.Services
{
    public class NoteDapperService
    {
        private readonly string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NotesApp_DB";

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var sqlQuery = "select * from dbo.Note";

                var notes = connection.Query<Note>(sqlQuery);
                return notes;
            }
        }

        public Note GetByUserIdAndNoteId(int userId, int noteId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlQuery = @"Select * from dbo.Note where Id = @noteId and UserId = @userId";

                var note = connection.Query<Note>(sqlQuery, new { userId, noteId }).FirstOrDefault();

                return note;
            }
        }

        public void Add(string text, string color, int tag, int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sqlQuery = @"insert into [dbo].[Note]([Text], [Color], [Tag], [UserId]) VALUES (@text, @color, @tag, @userId)";

                connection.Query(sqlQuery, new {text, color, tag, userId });
            }
        }
    }
}

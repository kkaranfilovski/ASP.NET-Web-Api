using SEDC.WebApi.Class08.AdoNET.Models;
using System.Data.SqlClient;

namespace SEDC.WebApi.Class08.AdoNET.Services
{
    public class NoteService
    {
        private readonly string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NotesApp_DB";

        public IEnumerable<Note> GetAllNotes()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "select * from dbo.Note";

            SqlDataReader reader = cmd.ExecuteReader();

            var notes = new List<Note>();

            while (reader.Read())
            {
                var note = new Note
                {
                    Id = (int)reader["Id"],
                    Color = (string)reader["Color"],
                    Text = (string)reader["Text"],
                    Tag = (int)reader["Tag"],
                    UserId = (int)reader["UserId"],
                };
                notes.Add(note);
            }

            connection.Close();
            return notes;
        }

        public Note GetNoteByUserId(int userId, int noteId)
        {
            string sqlInjection = $@"0;insert into dbo.Note (Text, Color, tag, UserId) VALUES('Test inj', 'Red', 4, 1);";
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;

                //cmd.CommandText = $"select * from dbo.Note where Id = {sqlInjection}";

                cmd.CommandText = "select * from dbo.Note where Id = @id and UserId = @userId";
                cmd.Parameters.AddWithValue("@id", noteId);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();

                var note = new Note();

                while (reader.Read())
                {
                    note = new Note
                    {
                        Id = (int)reader["Id"],
                        Color = (string)reader["Color"],
                        Text = (string)reader["Text"],
                        Tag = (int)reader["Tag"],
                        UserId = (int)reader["UserId"],
                    };
                }

                return note;
            }
        }

        public void Add(string text, string color, int tag, int userId)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var cmd = new SqlCommand();
                    cmd.Connection = connection;

                    cmd.CommandText = "insert into dbo.Note (Text, Color, Tag, UserId) Values(@text, @color, @tag, @userId)";

                    cmd.Parameters.AddWithValue("@text", text);
                    cmd.Parameters.AddWithValue("@color", color);
                    cmd.Parameters.AddWithValue("@tag", tag);
                    cmd.Parameters.AddWithValue("@userId", userId);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
                finally
                {

                }
            }
        }
    }
}

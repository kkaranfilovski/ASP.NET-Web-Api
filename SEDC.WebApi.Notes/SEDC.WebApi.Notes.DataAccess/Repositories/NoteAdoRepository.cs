using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using SEDC.WebApi.Notes.Common.Models;
using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DataAccess.Repositories
{
    public class NoteAdoRepository : IRepository<Note>
    {
        private readonly string _connectionString;

        public NoteAdoRepository(IOptions<AppSettings> appSetings)
        {
            _connectionString = appSetings.Value.ConnString;
        }

        public IEnumerable<Note> FilterBy(Func<Note, bool> filter)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = "select * from dbo.Note";

                try
                {
                    connection.Open();

                    SqlCommand cmd = new();
                    cmd.CommandText = sqlQuery;
                    cmd.Connection = connection;

                    var reader = cmd.ExecuteReader();
                    List<Note> notes = new();

                    while (reader.Read())
                    {
                        var note = new Note
                        {
                            Id = (int)reader["id"],
                            Text = (string)reader["Text"],
                            Color = reader["Color"].ToString(),
                            Tag = (int)reader["Tag"],
                            UserId = (int)reader["UserId"]
                        };
                        notes.Add(note);
                    }

                    return notes.Where(filter);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public IEnumerable<Note> GetAll()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                var sqlQuery = "select * from dbo.Note";

                try
                {
                    connection.Open();

                    SqlCommand cmd = new();
                    cmd.CommandText = sqlQuery;
                    cmd.Connection = connection;

                    var reader = cmd.ExecuteReader();
                    List<Note> notes = new();

                    while (reader.Read())
                    {
                        var note = new Note
                        {
                            Id = (int)reader["id"],
                            Text = (string)reader["Text"],
                            Color = reader["Color"].ToString(),
                            Tag = (int)reader["Tag"],
                            UserId = (int)reader["UserId"]
                        };
                        notes.Add(note);
                    }

                    return notes;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public Note GetById(int id)
        {
            var sqlQuery = "select * from dbo.Note where Id = @id";

            using(SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new();
                    cmd.CommandText = sqlQuery;
                    cmd.Connection = connection;

                    var reader = cmd.ExecuteReader();
                    List<Note> notes = new();

                    while (reader.Read())
                    {
                        var note = new Note
                        {
                            Id = (int)reader["id"],
                            Text = (string)reader["Text"],
                            Color = reader["Color"].ToString(),
                            Tag = (int)reader["Tag"],
                            UserId = (int)reader["UserId"]
                        };
                        notes.Add(note);
                    }

                    return notes.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int Insert(Note entity)
        {
            var sqlQuery = @"insert into dbo.Note([Text], [Color], [Tag], [UserId])
                             values(@text, @color, @tag, @userId)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new();
                    cmd.CommandText = sqlQuery;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@text", entity.Text);
                    cmd.Parameters.AddWithValue("@color", entity.Color);
                    cmd.Parameters.AddWithValue("@tag", entity.Tag);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId);

                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int Update(Note entity)
        {
            var sqlQuery = @"update dbo.Note
                             SET
                             Text = @text
                             Color = @color
                             Tag = @tag
                             UserId = @userId
                             WHERE Id = @id";
                               
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new()
                    {
                        CommandText = sqlQuery,
                        Connection = connection
                    };
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@text", entity.Text);
                    cmd.Parameters.AddWithValue("@color", entity.Color);
                    cmd.Parameters.AddWithValue("@tag", entity.Tag);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId);

                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int Delete(Note entity)
        {
            var sqlQuery = @"delete from dbo.Note where Id = @id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new()
                    {
                        CommandText = sqlQuery,
                        Connection = connection
                    };
                    cmd.Parameters.AddWithValue("@id", entity.Id);
                    cmd.Parameters.AddWithValue("@text", entity.Text);
                    cmd.Parameters.AddWithValue("@color", entity.Color);
                    cmd.Parameters.AddWithValue("@tag", entity.Tag);
                    cmd.Parameters.AddWithValue("@userId", entity.UserId);

                    var rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}

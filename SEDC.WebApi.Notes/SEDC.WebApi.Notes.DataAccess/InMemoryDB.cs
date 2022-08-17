using SEDC.WebApi.Notes.DataModels.Models;

namespace SEDC.WebApi.Notes.DataAccess
{
    public static class InMemoryDB
    {
        public static List<User> Users { get; set; } = new List<User>
        {
            new User()
            {
                Id = 1,
                FirstName = "Kristijan",
                LastName = "Karanfilovski",
                NoteList = new List<Note>(),
                Password = "123",
                UserName = "kiko"
            }
        };

        public static List<Note> Notes { get; set; } = new List<Note>
        {
            new Note()
            {
                Id=1,
                Color = "orange",
                Tag = 1,
                Text = "Hello",
                User = Users[0],
                UserId = 1,
            },
            new Note()
            {
                Id=2,
                Color = "blue",
                Tag = 1,
                Text = "Bye",
                User = Users[0],
                UserId = 1,
            }
        };
    }
}

using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain.Models
{
    public partial class User
    {
        public User()
        {
            MovieUsers = new HashSet<MovieUser>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int FavoriteGenre { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<MovieUser> MovieUsers { get; set; }
    }
}

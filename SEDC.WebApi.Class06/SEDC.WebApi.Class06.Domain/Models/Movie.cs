using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.Domain.Models
{
    public partial class Movie
    {
        public Movie()
        {
            MovieUsers = new HashSet<MovieUser>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Year { get; set; }
        public int Genre { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual ICollection<MovieUser> MovieUsers { get; set; }
    }
}

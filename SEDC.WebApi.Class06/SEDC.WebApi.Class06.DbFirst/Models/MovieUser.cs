using System;
using System.Collections.Generic;

namespace SEDC.WebApi.Class06.DbFirst.Models
{
    public partial class MovieUser
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }

        public virtual Movie Movie { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}

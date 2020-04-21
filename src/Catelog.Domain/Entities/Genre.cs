using System;
using System.Collections.Generic;
using System.Text;

namespace Catelog.Domain.Entities
{
    public class Genre
    {
        public Guid GenreId { get; set; }
        public string GenreDescription { get; set; }
    }
}

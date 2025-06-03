using Movies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Models
{
    public class Genre : BaseModel
    {
        public List<Movie> Movies { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Model
    {
        public string MovieName { get; set; }
        public string ReleaseYear { get; set; }
        public string Duration { get; set; }
        public string IMDBRating { get; set; }
        public string Metascore { get; set; }
        public string Votes { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Gross { get; set; }
    }
}

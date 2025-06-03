using Movies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class DataService
    {
        private readonly MoviesDbContext dbContext;

        public DataService(MoviesDbContext context)
        {
            context = dbContext;
            
        }

        public List<Movie> GetMoviesWithDogInThem()
        {
           return dbContext.Movies.Where(m => m.Name).ToList();
        }
    }
}

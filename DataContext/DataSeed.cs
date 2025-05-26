using CsvHelper;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Movies.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class DataSeed
    {
        private readonly MoviesDbContext _context;
        private readonly ICsvFileReader _csvReader;

        public DataSeed (MoviesDbContext context, ICsvFileReader csvReader)
        {
            _context = context;
            _csvReader = csvReader;
        }

        public void SeedMovies()
        {
            if (_context.Movies.Any()) return;

            var moviesFromCsv = _csvReader.GetData();

            foreach (var csvMovie in moviesFromCsv)
            {
                var director = _context.Directors
                    .FirstOrDefault(d => d.Name == csvMovie.Director)
                    ?? new Director { Name = csvMovie.Director };

                var cast = _context.Casts
                    .FirstOrDefault(c => c.Name == csvMovie.Cast)
                    ?? new Cast { Name = csvMovie.Cast };

                var genres = csvMovie.Genre
                    .Split(',')
                    .Select(g => g.Trim())
                    .Distinct()
                    .Select(name =>
                        _context.Genres.FirstOrDefault(gg => gg.Name == name)
                        ?? new Genre { Name = name })
                    .ToList();

                var movie = new Movie
                {
                    Name = csvMovie.MovieName,
                    Duration = csvMovie.Duration,
                    IMDBRating = csvMovie.IMDBRating,
                    Metascore = csvMovie.Metascore,
                    Vote = csvMovie.Votes,
                    Gross = csvMovie.Gross,
                    ReleaseYear = csvMovie.ReleaseYear,
                    Director = director,
                    Cast = cast,
                    Genres = genres
                };

                _context.Movies.Add(movie);
               // Console.WriteLine($"Добавен филм: {movie.Name}");

            }
            _context.SaveChanges();
        }
       
    }
}

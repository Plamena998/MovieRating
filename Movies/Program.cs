
using DataContext;
using Infrastructure;

public class Program
{
     private static void Main(string[] args)
    {
           
        using (var context = new MoviesDbContext())
        {
            CsvFileReader csv = new CsvFileReader();
            csv.GetData();
            var dataSeed = new DataSeed(context, csv);
            dataSeed.SeedMovies();
        }
    }
}

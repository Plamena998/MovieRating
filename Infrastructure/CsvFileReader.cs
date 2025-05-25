using System.Globalization;
using CsvHelper;
using System.Collections.Immutable;
namespace Infrastructure
{
    public class CsvFileReader : ICsvFileReader
    {
        public List<Model> GetData()
        {
            using (var reader = new StreamReader(GlobalParams.GlobalParam.fileDir))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ModelClassMap>();
                var movies = csv.GetRecords<Model>()
                    .Where(m => !string.IsNullOrWhiteSpace(m.MovieName))
                    .ToList();
                return movies;
            }
        }
    }
}

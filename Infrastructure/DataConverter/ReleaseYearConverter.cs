using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;

namespace Infrastructure.DataConverter
{
    public class ReleaseYearConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            var yearPart = text.Split('-')[0];
            if (int.TryParse(yearPart, out int year))
                return year;

            return 0;
        }
    }
}

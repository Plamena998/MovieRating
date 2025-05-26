using CsvHelper.Configuration;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.TypeConversion;

namespace Infrastructure.DataConverter
{
    public class GrossConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string? text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0.0;

            text = text.Trim().Replace("$", "").ToUpper();
            double multiplier = 1_000_000;

            if (text.EndsWith("M"))
            {
                text = text.Replace("M", "");
            }

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
            {
                return value * multiplier;
            }

            return 0.0;
        }
    }
}

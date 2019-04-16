using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using WeatherCollector.Entities;

namespace WeatherCollector.Helpers
{
    public class XlsParser
    {
        public static IEnumerable<Weather> Parse(Stream path)
        {
            XSSFWorkbook xssfWB;
            try
            {
                xssfWB = new XSSFWorkbook(path);
            }
            catch
            {
                yield break;
            }

            for (int i = 0; i < xssfWB.NumberOfSheets; i++)
            {
                var sheet = xssfWB.GetSheetAt(i);

                var n = 4;
                var row = sheet.GetRow(n);

                while (row != null)
                {
                    var weather = CreateInstanse(row);
                    if (InstanceCheck(weather))
                    {
                        yield return weather;
                    }
                    row = sheet.GetRow(++n);
                }
            }
        }

        public static Weather CreateInstanse(IRow row)
        {
            var weather = new Weather();

            if (row.Cells.Count >= 1 && DateTime.TryParseExact(row.GetCell(0).ToString(),"dd.MM.yyyy", null, DateTimeStyles.None, out DateTime date))
            {
                weather.Date = date;
            }

            if (row.Cells.Count >= 2 && TimeSpan.TryParse(row.GetCell(1).ToString(), out TimeSpan time))
            {
                weather.Time = time;
            }

            if(row.Cells.Count >= 3 && double.TryParse(row.GetCell(2).ToString(), out double airTemper))
            {
                weather.AirTemperature = airTemper;
            }

            if (row.Cells.Count >= 4 && double.TryParse(row.GetCell(3).ToString(), out double humidity))
            {
                weather.Humidity = humidity;
            }

            if (row.Cells.Count >= 5 && double.TryParse(row.GetCell(4).ToString(), out double dewPoint))
            {
                weather.DewPoint = dewPoint;
            }

            if (row.Cells.Count >= 6 && int.TryParse(row.GetCell(5).ToString(), out int pressure))
            {
                weather.Pressure = pressure;
            }

            if (row.Cells.Count >= 7)
            {
                weather.WindDirection = row.GetCell(6).ToString();
            }

            if (row.Cells.Count >= 8 && int.TryParse(row.GetCell(7).ToString(), out int windSpeed))
            {
                weather.WindSpeed = windSpeed;
            }

            if (row.Cells.Count >= 9 && int.TryParse(row.GetCell(8).ToString(), out int overCast))
            {
                weather.Overcast = overCast;
            }

            if (row.Cells.Count >= 10 && int.TryParse(row.GetCell(9).ToString(), out int cloudBase))
            {
                weather.CloudBase = cloudBase;
            }

            if (row.Cells.Count >= 11 && int.TryParse(row.GetCell(10).ToString(), out int horizontalVisib))
            {
                weather.HorizontalVisibility = horizontalVisib;
            }

            if (row.Cells.Count >= 12)
            {
                weather.WeatherConditions = row.GetCell(11).ToString();
            }

            return weather;
        }

        public static bool InstanceCheck(Weather weather)
        {
            if (!weather.Date.HasValue)
            {
                return false;
            }

            if (!weather.Time.HasValue)
            {
                return false;
            }

            if (!weather.AirTemperature.HasValue)
            {
                return false;
            }

            return true;
        }
    }
}

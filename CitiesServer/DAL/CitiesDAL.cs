using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Globalization;
using System.IO;
using CsvHelper;
using CitiesServer.Entities;
using System.Data;


namespace CitiesServer.DAL
{
    public static class CitiesDAL
    {
        public static List<string> AllCities;
        public static List<string> GetData()
        {
            List<string> allCities = new List<string>();
            using var streamReader = File.OpenText(@"DATA\\world-cities_csv.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var cities = csvReader.GetRecords<City>();

            foreach (var city in cities.ToArray())
            {
                allCities.Add(city.name);

            }

            return allCities;
        }


    }
}

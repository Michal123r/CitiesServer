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
        public static List<City> AllCities;
        public static List<City> GetData()
        {
            List<City> allCities = new List<City>();
            using var streamReader = File.OpenText(@"DATA\\world-cities_csv.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var cities = csvReader.GetRecords<City>();

            foreach (var city in cities.ToArray())
            {
                allCities.Add(new City { name = city.name });

            }

            return allCities;
        }


    }
}

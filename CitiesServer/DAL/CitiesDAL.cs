using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Globalization;
using System.IO;
using CsvHelper;
using CitiesServer.Entities;

namespace CitiesServer.DAL
{
    public static class CitiesDAL
    {
        public static void GetData()
        {
            using var streamReader = File.OpenText(@"DATA\\world-cities_csv.csv");
            using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

            var cities= csvReader.GetRecords<Object>();

            foreach (var user in cities)
            {
                Console.WriteLine(user);
            }

            //record City(string FirstName, String LastName, string Occupation);
        }
    }
}

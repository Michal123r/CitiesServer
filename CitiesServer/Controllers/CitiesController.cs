using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CitiesServer.DAL;
using Microsoft.AspNetCore.Cors;
using CitiesServer.Entities;

namespace CitiesServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }
        [EnableCors]
        [HttpGet]
        public IEnumerable<City> Get()
        {
            List<City> allCities;
            allCities = CitiesDAL.AllCities == null ? CitiesDAL.GetData() : CitiesDAL.AllCities;
            return allCities.ToArray();
            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}

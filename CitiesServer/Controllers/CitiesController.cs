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
        private readonly ILogger<CitiesController> _logger;

        public CitiesController(ILogger<CitiesController> logger)
        {
            _logger = logger;
        }
        [EnableCors]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> allCities;
            allCities = CitiesDAL.AllCities == null ? CitiesDAL.GetData() : CitiesDAL.AllCities;
            return allCities.ToArray();
           
        }
    }
}

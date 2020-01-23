using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _ownerRepository; 
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(ILoggerManager logger, IRepositoryWrapper ownerRepository)
        {
            _logger = logger;
            _ownerRepository = ownerRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _ownerRepository.Owner.Create(new Owner
            {
                Address = "Test",
                Name = "John"
            });
            _ownerRepository.Save();
            var owners = _ownerRepository.Owner.FindAll();
            return Ok(owners);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemoSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly ITransientService _transientService1;
        private readonly ITransientService _transientService2;

        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;

        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            ITransientService TransientService1, ITransientService TransientService2,
            IScopedService ScopedService1, IScopedService ScopedService2,
            ISingletonService SingletonService1, ISingletonService SingletonService2)
        {
            _logger = logger;

            _transientService1 = TransientService1;
            _transientService2 = TransientService2;

            _scopedService1 = ScopedService1;
            _scopedService2 = ScopedService2;

            _singletonService1 = SingletonService1;
            _singletonService2 = SingletonService2;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("GetLifeTimes")]
        public ActionResult<String> GetLifetimes()
        {
            StringBuilder values = new StringBuilder();

            values.AppendLine($"Transient Obj 1 - > {_transientService1.GetInstanceId().ToString()}");
            values.AppendLine($"Transient Obj 2 - > {_transientService2.GetInstanceId().ToString()}");
            values.AppendLine($"Scoped Obj 1 - > {_scopedService1.GetInstanceId().ToString()}");
            values.AppendLine($"Scoped Obj 2 - > {_scopedService2.GetInstanceId().ToString()}");
            values.AppendLine($"Singleton Obj 1 - > {_singletonService1.GetInstanceId().ToString()}");
            values.AppendLine($"Singleton Obj 1 - > {_singletonService2.GetInstanceId().ToString()}");



            return values.ToString();
        }
    }
}

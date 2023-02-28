using Microsoft.AspNetCore.Mvc;


namespace ParallelRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<AuthenticateController> _logger;

        public AppointmentController(ILogger<AuthenticateController> logger)
        {
            _logger = logger;
        }

        [Route("medical-record")]
        public IEnumerable<WeatherForecast> Get()
        {

            return null;
  
        }

    }
}
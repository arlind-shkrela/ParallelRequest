using Microsoft.AspNetCore.Mvc;

namespace ParallelRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemographicsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<AuthenticateController> _logger;

        public DemographicsController(ILogger<AuthenticateController> logger)
        {
            _logger = logger;
        }

        [Route("/patient-demographics")]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/demographics?UserPatientLinkToken=UhpzBKqj5n4uLbMsUk35hy");
            request.Headers.Add("X-API-EndUserSessionId", "PrvFAsY7xrc2nxtngkFEV3");
            request.Headers.Add("X-API-SessionId", "C2xe4ibNi3B6qGKZ6NJHKp");
            request.Headers.Add("X-API-Version", "2.1.0.0");
            request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            return Ok(await response.Content.ReadAsStringAsync());

        }

    }
}
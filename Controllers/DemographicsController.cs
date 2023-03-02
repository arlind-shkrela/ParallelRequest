using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParallelRequest.DTO;

namespace ParallelRequest.Controllers
{
    //[ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class DemographicsController : ControllerBase
    {

        private readonly ILogger<DemographicsController> _logger;

        public DemographicsController(ILogger<DemographicsController> logger)
        {
            _logger = logger;
        }

        [Route("/demographics")]
        [HttpGet]
        public async Task<DemographicsResponseDTO> GetDemographics()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/demographicsrequest?UserPatientLinkToken=WzHYk7Rk9uNLEZv82TE1BU");
            request.Headers.Add("X-API-EndUserSessionId", "WSj8Rw6UhUp7uin32mteJz");
            request.Headers.Add("X-API-SessionId", "WzHYk7Rk9uNLEZv82TE1BU");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var demographics =  JsonConvert.DeserializeObject<DemographicsResponseDTO>(await response.Content.ReadAsStringAsync());
            return demographics;
        }

        [Route("/patient-demographics")]
        [HttpGet]
        public async Task<IActionResult> GetPatientDemographics()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/demographics?UserPatientLinkToken=UhpzBKqj5n4uLbMsUk35hy");
            request.Headers.Add("X-API-EndUserSessionId", "PrvFAsY7xrc2nxtngkFEV3");
            request.Headers.Add("X-API-SessionId", "C2xe4ibNi3B6qGKZ6NJHKp");
            request.Headers.Add("X-API-Version", "2.1.0.0");
            request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://185.13.72.81/pfs/demographicsrequest");
            request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
            request.Headers.Add("X-API-SessionId", "2ZUdcrJ98FEtmJPF5GLEeC");
            var content = new StringContent("{\r\n  \"UserPatientLinkToken\": \"QEUuUspX4EVvjcvh1CVpf2\",\r\n  \"ContactDetails\": {\r\n    \"TelephoneNumber\": \"0773383723\",\r\n    \"MobileNumber\": \"0773383723\",\r\n    \"EmailAddress\": \"test@test.com\"\r\n  },\r\n  \"Address\": {\r\n    \"HouseNameFlatNumber\": \"1\",\r\n    \"NumberStreet\": \"1\",\r\n    \"Village\": \"Wakefield\",\r\n    \"Town\": \"Wakefield\",\r\n    \"County\": \"West Yorkshire\",\r\n    \"Postcode\": \"WF21UY\"\r\n  }\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());
        }
     
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://185.13.72.81/pfs/demographicsrequest");
            request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
            request.Headers.Add("X-API-SessionId", "2ZUdcrJ98FEtmJPF5GLEeC");
            var content = new StringContent("{\r\n  \"UserPatientLinkToken\": \"QEUuUspX4EVvjcvh1CVpf2\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());

        }
    }
}
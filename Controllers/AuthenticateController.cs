using Microsoft.AspNetCore.Mvc;

namespace ParallelRequest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {

        private readonly ILogger<AuthenticateController> _logger;

        public AuthenticateController(ILogger<AuthenticateController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "endusersession")]
        [Route("/endusersession")]
        [HttpPost]
        public async Task<IActionResult> Get()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://185.13.72.81/pfs/sessions/endusersession");
            request.Headers.Add("X-API-EndUserSessionId", "Drbz8mse7K8LjMrHYTSPLs");
            request.Headers.Add("X-API-Version", "2.1.0.0");
            request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
            var content = new StringContent("{\r\n  \"AccessIdentityGuid\": \"D66BA979-60D2-49AA-BE82-AEC06356E41F\",\r\n  \"NationalPracticeCode\": \"A28579\"\r\n}", null, "application/json-patch+json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());
        }

        //[HttpGet(Name = "sessions")]
        [Route("/sessions")]
        [HttpPost]
        public async Task<IActionResult> Sessions()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://185.13.72.81/pfs/sessions");
            request.Headers.Add("X-API-EndUserSessionId", "LJZfhUCGYpBFpUhUg9rajV");
            request.Headers.Add("X-API-Version", "2.1.0.0");
            request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
            var content = new StringContent("// Doris Day Access ID \r\n{\r\n  \"AccessIdentityGuid\": \"6dc7ae64-a1dd-481e-a735-f82d3bf48407\",\r\n  \"NationalPracticeCode\": \"A28579\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());


        }

    }
}
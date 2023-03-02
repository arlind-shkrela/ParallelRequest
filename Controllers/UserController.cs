using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParallelRequest.Models;

namespace ParallelRequest.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://185.13.72.81/pfs/users");
            request.Headers.Add("Version", "2.1.0.0");
            request.Headers.Add("ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
            request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
            var content = new StringContent("{\r\n  \"NationalPracticeCode\": \"A28579\",\r\n  \"RegistrationDetails\": {\r\n    \"ContactDetails\": {\r\n      \"TelephoneNumber\": \"(01234) 567890\",\r\n      \"MobileNumber\": \"(01234) 567890\",\r\n      \"EmailAddress\": \"doris.day@test.com\"\r\n    },\r\n    \"Address\": {\r\n      \"HouseNameFlatNumber\": \"\",\r\n      \"NumberStreet\": \"20 Main Street\",\r\n      \"Village\": \"\",\r\n      \"Town\": \"Leeds\",\r\n      \"County\": \"\",\r\n      \"Postcode\": \"LS1 6AB\"\r\n    }\r\n  },\r\n  \"SearchCriteria\": {\r\n    \"AssociationType\": \"None\",\r\n    \"DateOfBirth\": \"1939-01-01\",\r\n    \"FirstName\": \"Doris\",\r\n    \"Postcode\": \"LS1 6AB\",\r\n    \"Sex\": \"Female\",\r\n    \"Surname\": \"Day\",\r\n    \"Title\": \"Mrs\"\r\n  }\r\n}", null, "application/json-patch+json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());

        }
    }
}

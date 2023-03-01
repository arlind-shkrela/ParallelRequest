using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using ParallelRequest.DTO;
using ParallelRequest.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParallelRequest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalController : ControllerBase
    {

        private readonly ILogger<MedicalController> _logger;

        public MedicalController(ILogger<MedicalController> logger)
        {
            _logger = logger;
        }


        [Route("/synch-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetMedicalRecord(int requestNo)
        {
            var watch = new Stopwatch();
            watch.Start();
            var client = new HttpClient();
            for (int i = 0; i < requestNo; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/record?UserPatientLinkToken=QEUuUspX4EVvjcvh1CVpf2&ItemType=Documents");
                request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
                request.Headers.Add("X-API-SessionId", "2ZUdcrJ98FEtmJPF5GLEeC");
                request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
                request.Headers.Add("X-API-Version", "2.1.0.0");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var record = JsonConvert.DeserializeObject<MedicalRecordResponseDTO>(await response.Content.ReadAsStringAsync());

            }
            watch.Stop();
            this.Response.Headers.Add("Request-Milliseconds", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));
            return Ok();
        }

        [Route("/parallel-medical-record")]
        [HttpGet]
        public async Task<HttpResponseMessage[]> GetManyMedical(int requestNo)
        {
            var watch = new Stopwatch();
            watch.Start();
            var tasks = new List<Task<HttpResponseMessage>>();
            int numberOfRequests = requestNo;
            int batchSize = 100;
            int batchCount = (int)Math.Ceiling((decimal)numberOfRequests / batchSize);

            for (int i = 0; i < batchCount; ++i)
            {
                for (int j = 0; j < batchSize; ++j)
                {
                    tasks.Add(MakeRequestAsync(new Uri("http://185.13.72.81/pfs/record?UserPatientLinkToken=QEUuUspX4EVvjcvh1CVpf2&ItemType=Documents")));
 
                }

                await Task.WhenAll(tasks.ToArray());
            }

            watch.Stop();
            this.Response.Headers.Add("Request-Milliseconds", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));
            return await Task.WhenAll(tasks.ToArray());

        }

        private async Task<HttpResponseMessage> MakeRequestAsync(Uri uri)
        {
            try
            {

                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
                request.Headers.Add("X-API-SessionId", "2ZUdcrJ98FEtmJPF5GLEeC");
                request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
                request.Headers.Add("X-API-Version", "2.1.0.0");


                //using var httpClient = HttpClientFactory.Create();

                return await client.SendAsync(request);
            }
            catch
            {
                // Ignore any exception to continue loading other URLs.
                // You should definitely log the exception in a real
                // life application.
                return new HttpResponseMessage();
            }
        }

    }
}

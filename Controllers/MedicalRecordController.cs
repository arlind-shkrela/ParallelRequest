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
    public class MedicalRecordController : ControllerBase
    {

        private readonly ILogger<MedicalRecordController> _logger;

        public MedicalRecordController(ILogger<MedicalRecordController> logger)
        {
            _logger = logger;
        }


        [Route("/async-await-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetMedicalRecord(int requestNo, string endUserSessionId, string sessionId, string userPatientLinkToken)
        {
            var watch = new Stopwatch();
            watch.Start();
            var client = new HttpClient();
            for (int i = 0; i < requestNo; i++)
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"http://185.13.72.81/pfs/record?UserPatientLinkToken={userPatientLinkToken}");
                request.Headers.Add("X-API-EndUserSessionId", endUserSessionId);
                request.Headers.Add("X-API-SessionId", sessionId);
                request.Headers.Add("X-API-ApplicationId", "D66BA979-60D2-49AA-BE82-AEC06356E41F");
                request.Headers.Add("X-API-Version", "2.1.0.0");
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            watch.Stop();
            this.Response.Headers.Add("Request-Milliseconds", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));
            return Ok();

        }

        [Route("/in-parallel-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetManyInParallelMedical(int requestNo, string endUserSessionId, string sessionId, string userPatientLinkToken)
        {
            var watch = new Stopwatch();
            watch.Start();
            var tasks = new List<Task<HttpResponseMessage>>();

            for (int i = 0; i < requestNo; i++)
            {
                tasks.Add(MakeRequestAsync(new Uri($"http://185.13.72.81/pfs/record?UserPatientLinkToken={userPatientLinkToken}"), endUserSessionId, sessionId));
            }
            await Task.WhenAll(tasks);

            this.Response.Headers.Add("Request-Milliseconds", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));
            return Ok();

        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/in-parallel-fixed-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetManyInParallelFixedMedical(int requestNo, string endUserSessionId, string sessionId, string userPatientLinkToken)
        {
            //var tasks = new List<Task<HttpResponseMessage>>();
            //var batchSize = 100;
            //int numberOfBatches = (int)Math.Ceiling((double)userIds.Count() / batchSize);

            //for (int i = 0; i < numberOfBatches; i++)
            //{
            //    var currentIds = userIds.Skip(i * batchSize).Take(batchSize);
            //    var tasks = currentIds.Select(id => client.GetUser(id));
            //    users.AddRange(await Task.WhenAll(tasks));
            //}

            //return users;
            return Ok();
        }


        [Route("/parallel-batches-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetManyMedical(int requestNo, string endUserSessionId, string sessionId, string userPatientLinkToken)
        {
            var watch = new Stopwatch();
            int count = 0;
            watch.Start();
            var tasks = new List<Task<HttpResponseMessage>>();
            int numberOfRequests = requestNo;
            int batchSize = 10;
            int batchCount = (int)Math.Ceiling((decimal)numberOfRequests / batchSize);

            for (int i = 0; i < batchCount; ++i)
            {
                for (int j = 0; j < batchSize; ++j)
                {
                    tasks.Add(MakeRequestAsync(new Uri($"http://185.13.72.81/pfs/record?UserPatientLinkToken={userPatientLinkToken}"), endUserSessionId, sessionId));
                    count++;
                }
            }
            await Task.WhenAll(tasks.ToArray());
            watch.Stop();
            this.Response.Headers.Add("Request-Milliseconds", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));
            this.Response.Headers.Add("Request", JsonConvert.SerializeObject(count));
            return Ok();

        }

        [Route("/TTFB-parallel-batches-medical-record")]
        [HttpGet]
        public async Task<IActionResult> GetTTFBManyMedical(string endUserSessionId, string sessionId, string userPatientLinkToken)
        {
            var watch = new Stopwatch();

            watch.Start();
            var tasks = new List<Task<HttpResponseMessage>>();
        
            await MakeRequestAsync(new Uri($"http://185.13.72.81/pfs/record?UserPatientLinkToken={userPatientLinkToken}"), endUserSessionId, sessionId);
          
            await Task.WhenAll(tasks.ToArray());
            watch.Stop();
            this.Response.Headers.Add("TTFB", JsonConvert.SerializeObject(watch.ElapsedMilliseconds));

            return Ok();

        }

        private async Task<HttpResponseMessage> MakeRequestAsync(Uri uri, string endUserSessionId, string sessionId)
        {
            try
            {

                HttpClient client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, uri);
                request.Headers.Add("X-API-EndUserSessionId", endUserSessionId);
                request.Headers.Add("X-API-SessionId", sessionId);
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

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParallelRequest.DTO;
namespace ParallelRequest.Controllers
{
    //[ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class AppointmentController : ControllerBase
    {

        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<AppointmentsResponseDTO> Appointment()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/appointments?UserPatientLinkToken=E7ghXJ4MuCqDH1t4256FwK&FetchPreviousAppointments=true&PreviousAppointmentsFromDate");
            request.Headers.Add("X-API-EndUserSessionId", "T6nqtSwCoS1ghknrMmQsj");
            request.Headers.Add("X-API-SessionId", "5TtqcnTesvzksKRj5WN9Tq");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var appointments = JsonConvert.DeserializeObject<AppointmentsResponseDTO>(await response.Content.ReadAsStringAsync());
            return appointments;

        }

        [Route("/appointment-slots")]
        [HttpGet]
        public async Task<AppointmentSlotsResponseDTO> AppointmentSlots()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/appointmentslots?UserPatientLinkToken=E7ghXJ4MuCqDH1t4256FwK&FromDateTime&ToDateTime&SessionId&LocationId&SessionType&ClinicianId&ClinicianSex");
            request.Headers.Add("X-API-EndUserSessionId", "T6nqtSwCoS1ghknrMmQsj");
            request.Headers.Add("X-API-SessionId", "5TtqcnTesvzksKRj5WN9Tq");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var appointmentSlots = JsonConvert.DeserializeObject<AppointmentSlotsResponseDTO>(await response.Content.ReadAsStringAsync());
            return appointmentSlots;

        }

        [Route("/appointment-slots-metadata")]
        [HttpGet]
        public async Task<AppointmentSlotsMetadataResponseDTO> AppointmentSlotsMetadata()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://185.13.72.81/pfs/appointmentslots/meta?UserPatientLinkToken=E7ghXJ4MuCqDH1t4256FwK&SessionStartDate&SessionEndDate");
            request.Headers.Add("X-API-EndUserSessionId", "T6nqtSwCoS1ghknrMmQsj");
            request.Headers.Add("X-API-SessionId", "5TtqcnTesvzksKRj5WN9Tq");
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

            var appointmentSlotsMetadata = JsonConvert.DeserializeObject<AppointmentSlotsMetadataResponseDTO>(await response.Content.ReadAsStringAsync());
            return appointmentSlotsMetadata;
        }


        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://185.13.72.81/pfs/appointments");
            request.Headers.Add("X-API-EndUserSessionId", "MeS5XVPyvFmQuswHp6o61H");
            request.Headers.Add("X-API-SessionId", "2ZUdcrJ98FEtmJPF5GLEeC");
            var content = new StringContent("// USE GET APPOINTMENT SLOTS IN ORDER TO GET SLOT IDs\r\n\r\n// Request model with Slot ID, booking reason and contact details\r\n\r\n{\r\n  \"UserPatientLinkToken\": \"QEUuUspX4EVvjcvh1CVpf2\",\r\n  \"SlotId\": 124855,\r\n  \"BookingReason\": \"\",\r\n  \"TelephoneNumber\": \"\",\r\n  \"TelephoneContactType\": \"Unknown\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return Ok(await response.Content.ReadAsStringAsync());

        }
    }
}
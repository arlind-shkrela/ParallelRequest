namespace ParallelRequest.Models
{
    public class Appointment
    {
        public int SlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BookingDate { get; set; }
        public string SlotTypeName { get; set; }
        public string SlotTypeStatus { get; set; }
        public int SessionId { get; set; }
        public string VidyoRoomUri { get; set; }
        public string BookingReason { get; set; }
        public string TelephoneAppointmentDetails { get; set; }
        public string BookingMethod { get; set; }

    }
}

namespace ParallelRequest.Models
{
    public class Slots
    {
        public int SlotId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string SlotTypeName { get; set; }
        public string SlotTypeStatus { get; set; }
    }
}

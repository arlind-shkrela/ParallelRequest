namespace ParallelRequest.Models
{
    public class FilterDetail
    {
        public string? ItemFilter { get; set; }
        public DateTime? ItemFilterFromDate { get; set; }
        public string? ItemFilterToDate { get; set; }
        public DateTime? FreeTextFilterFromDate { get; set; }
    }
}

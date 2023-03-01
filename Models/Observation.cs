namespace ParallelRequest.Models
{
    public class Observation
    {
        public string ObservationType { get; set; }
        public string Episodicity { get; set; }
        public object NumericValue { get; set; }
        public object NumericOperator { get; set; }
        public object NumericUnits { get; set; }
        public object DisplayValue { get; set; }
        public object TextValue { get; set; }
        public object Range { get; set; }
        public bool Abnormal { get; set; }
        public object AbnormalReason { get; set; }
        public List<AssociatedText> AssociatedText { get; set; }
        public string EventGuid { get; set; }
        public string Term { get; set; }
        public DateTime AvailabilityDateTime { get; set; }
        public EffectiveDate EffectiveDate { get; set; }
        public long CodeId { get; set; }
        public string AuthorisingUserInRoleGuid { get; set; }
        public string EnteredByUserInRoleGuid { get; set; }
    }
}

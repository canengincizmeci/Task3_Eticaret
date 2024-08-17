namespace SaticiFirmaPaneli.Models
{
    public class SocialResponsibilityTaskModel
    {
        public int TaskId { get; set; }

        public string? TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? ActivityStatus { get; set; }

        public bool? JoinStatus { get; set; }
    }
}

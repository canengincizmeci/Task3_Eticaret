namespace SaticiFirmaPaneli.Models
{
    public class CompanyCompetitionModel
    {
        public string? CompetitionTitle { get; set; }
        public int CompetitionId { get; set; }


        public int? CompanyCompetitionId { get; set; }

        public string? CompetitionDescription { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool? ActivityStatus { get; set; }
        public bool? JoinStatus { get; set; }

    }
}

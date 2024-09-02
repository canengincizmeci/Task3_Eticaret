namespace SatisPaneli.Models
{
    public class CompetitionModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? JoinStatus { get; set; }
    }
}

namespace SatisPaneli.Models
{
    public class GiweawaysModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public bool? JoinStatus { get; set; }
    }
}

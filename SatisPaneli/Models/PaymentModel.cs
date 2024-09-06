namespace SatisPaneli.Models
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }
        public bool? Approve { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public float? TotalPrice { get; set; }
        public DateTime? Date { get; set; }
        public string? CouponCode { get; set; }
        public int? CartId { get; set; }
        public string? CardNumber { get; set; }

    }
}

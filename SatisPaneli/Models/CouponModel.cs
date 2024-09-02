﻿namespace SatisPaneli.Models
{
    public class CouponModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
        public float? DiscountAmount { get; set; }
    }
}

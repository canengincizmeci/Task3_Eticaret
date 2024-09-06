﻿namespace SatisPaneli.Models
{
    public class ViewUserCartModel
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? ProductImage { get; set; }
        public string? CategoryName { get; set; }
        public string? UserName { get; set; }
        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public int? Price { get; set; }
        public int? Count { get; set; }
        public int? TotalPrice { get; set; }
        
    }
}

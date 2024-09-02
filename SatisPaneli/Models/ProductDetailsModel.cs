namespace SatisPaneli.Models
{
    public class ProductDetailsModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }


        public string? ProductImage { get; set; }

        public DateTime? AddingDate { get; set; }
        public string? CategoryName { get; set; }
        public int? CompanyId { get; set; }
        public string? CompanyName { get; set; }

        public int? Price { get; set; }

        public int? Stock { get; set; }

    }
}

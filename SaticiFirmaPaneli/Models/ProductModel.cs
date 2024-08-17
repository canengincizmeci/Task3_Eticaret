namespace SaticiFirmaPaneli.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public string? ProductImage { get; set; }

        public DateTime? AddedDate { get; set; }

        public int? CompanyId { get; set; }

        public int? SalesCount { get; set; }

        public int? Price { get; set; }

        public int? timesAddedToCart { get; set; }

        public int? Stock { get; set; }

        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public bool? ActivityStatus { get; set; }
        public List<ProductCommentModel>? comments { get; set; }
  

    }
}

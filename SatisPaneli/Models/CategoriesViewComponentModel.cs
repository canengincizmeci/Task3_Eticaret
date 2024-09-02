using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SatisPaneli.Models
{
    public class CategoriesViewComponentModel
    {
        public int? CategoryId { get; set; }

        public string? CategoryName { get; set; }
        public int? Count { get; set; }

    }
}

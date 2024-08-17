namespace SaticiFirmaPaneli.Models
{
    public class FavoritedProductsModel
    {
        public int FavoritedId { get; set; }

        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int? UserId { get; set; }
        public string? UserAd { get; set; }
        public bool? ActivityStatus { get; set; }


    }

}

namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Veg veg { get; set; }
        public string price { get; set; }
        public string ShopCartId { get; set; }
    }
}

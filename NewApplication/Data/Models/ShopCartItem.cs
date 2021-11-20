namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public int amount { get; set; }
        public Veg veg { get; set; }
        public ushort price { get; set; }
        public string ShopCartId { get; set; }
    }
}

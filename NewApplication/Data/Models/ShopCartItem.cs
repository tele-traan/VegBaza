namespace Shop.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Veg Veg { get; set; }
        public ushort Price { get; set; }
        public string ShopCartId { get; set; }
    }
}

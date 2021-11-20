namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderID { get; set; }
        public int VegID { get; set; }

        public ushort price { get; set; }
        public virtual Veg veg { get; set; }
        public virtual Order order { get; set; }
    }
}

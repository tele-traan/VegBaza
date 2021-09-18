namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int orderID { get; set; }
        public int VegID { get; set; }

        public string price { get; set; }
        public virtual Veg veg { get; set; }
        public virtual Order order { get; set; }
    }
}

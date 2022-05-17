namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int VegId { get; set; }

        public ushort Price { get; set; }
        public virtual Veg Veg { get; set; }
        public virtual Order Order { get; set; }
    }
}

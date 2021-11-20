using System.Collections.Generic;
namespace Shop.Data.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public string desc { get; set; }

        public List<Veg> vegs { get; set; }
    }
}

using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.ViewModels
{
    public class VegListViewModel
    {
        public IEnumerable<Veg> allVegs { get; set; }
        public string currCategory { get; set; }
        public ShopCart ShopCart;
    }
}
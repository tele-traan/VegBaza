using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.ViewModels
{
    public class VegListViewModel
    {
        public IEnumerable<Veg> AllVegs { get; set; }
        public string CurrCategory { get; set; }
        public ShopCart ShopCart;
    }
}
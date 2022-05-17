using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.ViewModels
{
    public class HomeViewModel 
    {
        public IEnumerable<Veg> FavVegs { get; set; }
    }
}

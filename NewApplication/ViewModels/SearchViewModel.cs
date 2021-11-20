using Shop.Data.Models;
using System.Collections.Generic;
namespace Shop.ViewModels
{
    public class SearchViewModel 
    {
        public IEnumerable<Veg> vegsFound { get; set; }
    }
}

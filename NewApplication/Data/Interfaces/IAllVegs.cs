using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.Data.Interfaces { 
    public interface IAllVegs {
        IEnumerable<Veg> Vegs { get; }
        IEnumerable<Veg> getFavVegs { get; }
        Veg getObjectVeg(int carId);
        IEnumerable<Veg> FindVegs(string key);
    }   
}
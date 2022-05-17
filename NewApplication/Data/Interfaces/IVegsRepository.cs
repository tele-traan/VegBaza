using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.Data.Interfaces { 
    public interface IVegsRepository
    {
        IEnumerable<Veg> GetAllVegs();
        IEnumerable<Veg> GetFavVegs();
        Veg GetObjectVeg(int vegId);
        IEnumerable<Veg> FindVegs(string key);
    }   
}
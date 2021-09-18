using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Shop.DB;
namespace Shop.Data.Repository
{
    public class VegRepository : IAllVegs
    {
        private readonly AppDBContent _appDbContent;

        public VegRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Veg> Vegs => _appDbContent.Veg.Include(c => c.Category);

        public IEnumerable<Veg> getFavVegs => _appDbContent.Veg.Where(p => p.isFavourite).Include(c => c.Category);

        public Veg getObjectVeg(int carId) => _appDbContent.Veg.FirstOrDefault(p => p.id == carId);
    }
}

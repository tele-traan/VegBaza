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

        public Veg getObjectVeg(int vegId) => _appDbContent.Veg.FirstOrDefault(p => p.id == vegId);

        public IEnumerable<Veg> FindVegs(string key)
        {
            List<Veg> result = new();
            if (!_appDbContent.Veg.Any() || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }
            else
            {
                foreach (var v in _appDbContent.Veg)
                {
                    if (v.name.Contains(key)
                      || v.longDesc.Contains(key)
                      || v.shortDesc.Contains(key)) result.Add(v);
                }
                return result;
            }
        }
    }
}
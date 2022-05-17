using Microsoft.EntityFrameworkCore;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Shop.DB;
namespace Shop.Data.Repository
{
    public class VegsRepository : IVegsRepository
    {
        private readonly AppDbContent _appDbContent;

        public VegsRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Veg> GetAllVegs()
            => _appDbContent.Veg.Include(c => c.Category);

        public IEnumerable<Veg> GetFavVegs() => _appDbContent.Veg.Where(p => p.IsFavourite).Include(c => c.Category);

        public Veg GetObjectVeg(int vegId) => _appDbContent.Veg.FirstOrDefault(p => p.Id == vegId);

        public IEnumerable<Veg> FindVegs(string key)
        {
            List<Veg> result = new();
            if (!_appDbContent.Veg.Any() || string.IsNullOrWhiteSpace(key))
            {
                return result;
            }
            foreach (var v in _appDbContent.Veg)
            {
                if (v.Name.Contains(key)
                  || v.LongDesc.Contains(key)
                  || v.ShortDesc.Contains(key)) result.Add(v);
            }
            return result;
        }
    }
}
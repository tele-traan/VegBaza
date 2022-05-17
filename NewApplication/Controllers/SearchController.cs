using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.DB;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.ViewModels;
using System.Linq;
using Shop.Data.Models;
namespace Shop.Controllers
{
    public class SearchController : Controller
    {
        private readonly IVegsRepository _vegRepositoryRep;
        private readonly AppDbContent _appDbContent;
        private readonly ShopCart _shopCart;
        public SearchController(IVegsRepository i, AppDbContent a, ShopCart s)
        {
            _vegRepositoryRep = i;
            _appDbContent = a;
            _shopCart = s;
        }
        [HttpGet]
        public async Task<IActionResult> Result(string key)
        {
            ViewData["GetDetails"] = key;
            var query = _appDbContent.Veg.AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                query = query.Where(x => x.Name.Contains(key) || x.Category.CategoryName.Contains(key));
            }
            var homeVegs = new SearchViewModel
            {
                VegsFound = await query.AsNoTracking().ToListAsync(), 
            };
            return View(homeVegs);
        }
    }
}
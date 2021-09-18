using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using Shop.DB;
namespace Shop.Data.Repository
{
    public class CategoryRepository : IVegsCategory
    {
        private readonly AppDBContent _appDbContent;

        public CategoryRepository(AppDBContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Category> AllCategories => _appDbContent.Category;
    }
}

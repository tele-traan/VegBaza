using Shop.Data.Interfaces;
using Shop.Data.Models;
using System.Collections.Generic;
using Shop.DB;
namespace Shop.Data.Repository
{
    public class CategoryRepository : IVegsCategory
    {
        private readonly AppDbContent _appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            _appDbContent = appDbContent;
        }
        public IEnumerable<Category> GetAllCategories()
            => _appDbContent.Category;
    }
}
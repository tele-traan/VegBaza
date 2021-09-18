using System.Collections.Generic;
using Shop.Data.Models;
namespace Shop.Data.Interfaces
{
    public interface IVegsCategory
    {
       IEnumerable<Category> AllCategories { get; }
    }
}
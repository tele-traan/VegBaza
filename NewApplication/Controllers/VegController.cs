using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.ViewModels;
using System.Collections.Generic;
using Shop.Data.Models;
using System.Linq;
using System;

namespace Shop.Controllers
{
    public class VegController : Controller
    {
        private readonly IAllVegs _allVegs;
        private readonly IVegsCategory _allCategory;

        public VegController(IAllVegs _allV, IVegsCategory _allVC)
        {
            _allVegs = _allV;
            _allCategory = _allVC;
        }
        [Route("Veg/List")]
        [Route("Veg/List/{category}")]
        public ViewResult List(string category)
        {
            IEnumerable<Veg> vegs = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                vegs = _allVegs.Vegs.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("cheap", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _allVegs.Vegs.Where(i => i.Category.categoryName.Equals("Дешёвые")).OrderBy(i => i.id);
                    currCategory = "Экономные";
                }
                else if (string.Equals("expsn", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _allVegs.Vegs.Where(i => i.Category.categoryName.Equals("Дорогие")).OrderBy(i => i.id);
                    currCategory = "";
                }
            }
            var vegObj = new VegListViewModel
            {
                allVegs = vegs,
                currCategory = currCategory,
            };
            return View(vegObj);
        }
    }
}
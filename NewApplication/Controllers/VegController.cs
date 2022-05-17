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
        private readonly IVegsRepository _vegsRepository;
        private readonly IVegsCategory _allCategory;
        private readonly ShopCart _shopCart;

        public VegController(IVegsRepository v, IVegsCategory allVc, ShopCart s)
        {
            _vegsRepository = v;
            _allCategory = allVc;
            _shopCart = s;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Veg> vegs = null;
            string currCategory;
            if (string.IsNullOrEmpty(category))
            {
                vegs = _vegsRepository.GetAllVegs().OrderBy(i => i.Id);
                currCategory = "Наборы";
            }
            else
            {
                if (string.Equals("cheap", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _vegsRepository.GetAllVegs().Where(i => i.Category.CategoryName.Equals("Дешёвые")).OrderBy(i => i.Id);
                    currCategory = "Экономные";
                }
                else if (string.Equals("expsn", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _vegsRepository.GetAllVegs().Where(i => i.Category.CategoryName.Equals("Дорогие")).OrderBy(i => i.Id);
                    currCategory = "Премиум-класс";
                }
                else
                {
                    currCategory = "Неизвестная ошибка. Обратитесь в тех-поддержку сайта";
                }
            }
            var vegObj = new VegListViewModel
            {
                AllVegs = vegs,
                CurrCategory = currCategory,
            };
            return View(vegObj);
        }
    }
}
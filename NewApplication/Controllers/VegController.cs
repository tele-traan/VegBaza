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
        private readonly ShopCart _shopCart;

        public VegController(IAllVegs _allV, IVegsCategory _allVC, ShopCart s)
        {
            _allVegs = _allV;
            _allCategory = _allVC;
            _shopCart = s;
        }
        public ViewResult List(string category)
        {
            IEnumerable<Veg> vegs = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                vegs = _allVegs.Vegs.OrderBy(i => i.id);
                currCategory = "������";
            }
            else
            {
                if (string.Equals("cheap", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _allVegs.Vegs.Where(i => i.Category.categoryName.Equals("�������")).OrderBy(i => i.id);
                    currCategory = "���������";
                }
                else if (string.Equals("expsn", category, StringComparison.OrdinalIgnoreCase))
                {
                    vegs = _allVegs.Vegs.Where(i => i.Category.categoryName.Equals("�������")).OrderBy(i => i.id);
                    currCategory = "�������-�����";
                }
                else
                {
                    currCategory = "����������� ������. ���������� � ���-��������� �����";
                }
            }
            var vegObj = new VegListViewModel
            {
                allVegs = vegs,
                currCategory = currCategory,
            };
            int count = 0;
            foreach (var v in _shopCart.getShopItems())
            {
                int amount = v.amount;
                while (amount != 0)
                {
                    count++; amount--;
                }
            }
            ViewData["ItemsCount"] = count;
            return View(vegObj);
        }
    }
}
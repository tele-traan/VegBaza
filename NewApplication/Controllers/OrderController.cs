using System;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Interfaces;
using Shop.MailServices;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrdersRepository _ordersRepository;
        private readonly ShopCart _shopCart;
        private readonly MailService _mailService;

        public OrderController(IOrdersRepository ia, ShopCart s, MailService m)
        {
            _ordersRepository = ia;
            _shopCart = s;
            _mailService = m;
        }

        public IActionResult CheckOut() =>View();
        
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            if (_shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина не должна быть пуста!");
            }

            if (!ModelState.IsValid) return View(order);
            _ordersRepository.CreateOrder(order);
            _mailService.SendEmail(order);
            return RedirectToAction("Complete");

        }
        public ViewResult Complete()
        {
            ViewBag.Message = "Успешно";
            _shopCart.ClearCart();
            ViewData["ItemsCount"] = 0;
            
            return View();
        } 
    }
}
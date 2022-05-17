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

        public OrderController(IOrdersRepository ia, ShopCart s)
        {
            _ordersRepository = ia;
            _shopCart = s;
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
            MailService.SendEmail(order);
            return RedirectToAction("Complete");

        }
        public ViewResult Complete()
        {
            ViewBag.Message = "Успешно";
            _shopCart.ClearCart();
            
            return View();
        } 
    }
}
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Interfaces;
using Shop.MailServices;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;
        private readonly MailService _mailService;

        public OrderController(IAllOrders ia, ShopCart s, MailService m)
        {
            _allOrders = ia;
            _shopCart = s;
            _mailService = m;
        }

        public IActionResult CheckOut()
        {
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
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shopCart.listShopItems = _shopCart.getShopItems();
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
            if (_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина не должна быть пуста!");
            }
            if (ModelState.IsValid)
            {
                _allOrders.createOrder(order);
                _mailService.SendEmail(order);
                return RedirectToAction("Complete");
            }
            return View(order);
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
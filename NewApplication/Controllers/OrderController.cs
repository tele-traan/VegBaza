using Microsoft.AspNetCore.Mvc;
using Shop.Data.Models;
using Shop.Data.Interfaces;
namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;

        public OrderController(IAllOrders ia, ShopCart s)
        {
            _allOrders = ia;
            _shopCart = s;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CheckOut(Order order)
        {
            _shopCart.listShopItems = _shopCart.getShopItems();

            if(_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина не должна быть пуста!");
            }
            if (ModelState.IsValid)
            {
                _allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public ViewResult Complete()
        {
            ViewBag.Message = "Заказ успешно оформлен.";
            return View();
        } 
    }
}

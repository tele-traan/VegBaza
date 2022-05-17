using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using Shop.DB;

namespace Shop.Data.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly AppDbContent _appDbContent;
        private readonly ShopCart _shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            _appDbContent = appDbContent;
            _shopCart = shopCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDbContent.Order.Add(order);
            _appDbContent.SaveChanges();

            var items = _shopCart.ListShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail
                {
                    VegId = el.Veg.Id,
                    OrderId = order.Id,
                    Price = el.Veg.Price
                };
                _appDbContent.OrderDetail.Add(orderDetail);
            }
            _appDbContent.SaveChanges();
        }
    }
}

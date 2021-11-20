using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Shop.Data.Models;
using System.Linq;

namespace Shop.Hubs
{
    public class CartHub : Hub
    {
        private readonly ShopCart _shopCart;
        public CartHub(ShopCart s)
        {
            _shopCart = s;
        }
        public async Task ActionWithItem(int id)
        {

            await Clients.All.SendAsync("Amount", $"LOLXD{id}");
        }
    }
}

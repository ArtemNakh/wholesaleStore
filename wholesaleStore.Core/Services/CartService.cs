using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository _context;

        public CartService(IRepository context)
        {
            _context = context;
        }

        public async Task AddToCart(CartItem cartItem)
        {
            await _context.Add(cartItem);
        }

        public async Task<IEnumerable<CartItem>> GetCartItems(User user)
        {
            return await _context.GetQuery<CartItem>(ci => ci.User.Id == user.Id);
        }

        public async Task<Goods> GetProductById(int productId)
        {
            return await _context.GetById<Goods>(productId);
        }

        public async Task AddOrder(Orders order)
        {
           await _context.Add(order);
        }

        public async Task ClearCart(User user)
        {
            IEnumerable<CartItem> cartItems = await _context.GetQuery<CartItem>(ci => ci.User.Id == user.Id);
            List<int> orderIds = cartItems.Select(c => c.Id).ToList();
            foreach (int cartItem in orderIds)
            {
                await _context.Delete<CartItem>(cartItem);
            }


        }
    }
}

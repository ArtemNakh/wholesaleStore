using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(CartItem cartItem);
        Task<IEnumerable<CartItem>> GetCartItems(User user);
        Task<Goods> GetProductById(int productId);
        Task AddOrder(Orders order);
        Task ClearCart(User user);
    }
}

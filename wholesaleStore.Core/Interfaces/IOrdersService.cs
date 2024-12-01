using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<Orders> AddOrder(Orders order);
        Task<Orders> GetOrderById(int id);
        Task<IEnumerable<Orders>> GetAllOrders();
        Task<Orders> UpdateOrder(Orders order);
        Task DeleteOrder(int id);
    }
}

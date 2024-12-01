using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository _repository;

        public OrdersService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Orders> AddOrder(Orders order)
        {
            return await _repository.Add(order);
        }

        public async Task<Orders> GetOrderById(int id)
        {
            return await _repository.GetById<Orders>(id);
        }

        public async Task<IEnumerable<Orders>> GetAllOrders()
        {
            return await _repository.GetAll<Orders>().ToListAsync();
        }

        public async Task<Orders> UpdateOrder(Orders order)
        {
            return await _repository.Update(order);
        }

        public async Task DeleteOrder(int id)
        {
            await _repository.Delete<Orders>(id);
        }
    }

}

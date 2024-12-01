
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
    public class EnterpriceService : IEnterpriceService
    {
        private readonly IRepository _repository;

        public EnterpriceService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Enterprice> AddEnterprice(Enterprice enterprice)
        {
            return await _repository.Add(enterprice);
        }

        public async Task<Enterprice> GetEnterpriceById(int id)
        {
            return await _repository.GetById<Enterprice>(id);
        }

        public async Task<IEnumerable<Enterprice>> GetAllEnterprices()
        {
            return await _repository.GetAll<Enterprice>().ToListAsync();
        }

        public async Task<Enterprice> UpdateEnterprice(Enterprice enterprice)
        {
            return await _repository.Update(enterprice);
        }

        public async Task DeleteEnterprice(int id)
        {
            await _repository.Delete<Enterprice>(id);
        }
    }
}

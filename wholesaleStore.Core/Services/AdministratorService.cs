
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
    public class AdministratorService : IAdministratorService
    {
        private readonly IRepository _repository;

        public AdministratorService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Administrator> AddAdministrator(Administrator administrator)
        {
            return await _repository.Add(administrator);
        }

        public async Task<Administrator> GetAdministratorById(int id)
        {
            return await _repository.GetById<Administrator>(id);
        }

        public async Task<IEnumerable<Administrator>> GetAllAdministrators()
        {
            return await _repository.GetAll<Administrator>().ToListAsync();
        }

        public async Task<Administrator> UpdateAdministrator(Administrator administrator)
        {
            return await _repository.Update(administrator);
        }

        public async Task DeleteAdministrator(int id)
        {
            await _repository.Delete<Administrator>(id);
        }
    }
}

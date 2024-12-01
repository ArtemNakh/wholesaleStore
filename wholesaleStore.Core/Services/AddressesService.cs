
using Microsoft.EntityFrameworkCore;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Services
{
    public class AddressesService : IAddressesService
    {
        private readonly IRepository _repository;

        public AddressesService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Addresses> AddAddress(Addresses address)
        {
            return await _repository.Add(address);
        }

        public async Task<Addresses> GetAddressById(int id)
        {
            return await _repository.GetById<Addresses>(id);
        }

        public async Task<IEnumerable<Addresses>> GetAllAddresses()
        {
            return await _repository.GetAll<Addresses>().ToListAsync();
        }

        public async Task<Addresses> UpdateAddress(Addresses address)
        {
            return await _repository.Update(address);
        }

        public async Task DeleteAddress(int id)
        {
            await _repository.Delete<Addresses>(id);
        }
    }


}

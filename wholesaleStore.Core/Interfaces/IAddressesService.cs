
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IAddressesService
    {
        Task<Addresses> AddAddress(Addresses address);
        Task<Addresses> GetAddressById(int id);
        Task<IEnumerable<Addresses>> GetAllAddresses();
        Task<Addresses> UpdateAddress(Addresses address);
        Task DeleteAddress(int id);
    }
}

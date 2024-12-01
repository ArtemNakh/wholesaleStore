
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IAdministratorService
    {
        Task<Administrator> AddAdministrator(Administrator administrator);
        Task<Administrator> GetAdministratorById(int id);
        Task<IEnumerable<Administrator>> GetAllAdministrators();
        Task<Administrator> UpdateAdministrator(Administrator administrator);
        Task DeleteAdministrator(int id);
    }
}

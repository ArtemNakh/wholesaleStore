
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IEnterpriceService
    {
        Task<Enterprice> AddEnterprice(Enterprice enterprice);
        Task<Enterprice> GetEnterpriceById(int id);
        Task<IEnumerable<Enterprice>> GetAllEnterprices();
        Task<Enterprice> UpdateEnterprice(Enterprice enterprice);
        Task DeleteEnterprice(int id);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IGoodsService
    {
        Task<Goods> AddGood(Goods good);
        Task<Goods> GetGoodById(int id);
        Task<IEnumerable<Goods>> GetAllGoods();
        Task<Goods> UpdateGood(Goods good);
        Task DeleteGood(int id);
    }
}

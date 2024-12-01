
using Microsoft.EntityFrameworkCore;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Services
{
    public class GoodsService : IGoodsService
    {
        private readonly IRepository _repository;

        public GoodsService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Goods> AddGood(Goods good)
        {
            return await _repository.Add(good);
        }

        public async Task<Goods> GetGoodById(int id)
        {
            return await _repository.GetById<Goods>(id);
        }

        public async Task<IEnumerable<Goods>> GetAllGoods()
        {
            return await _repository.GetAll<Goods>().ToListAsync();
        }

        public async Task<Goods> UpdateGood(Goods good)
        {
            return await _repository.Update(good);
        }

        public async Task DeleteGood(int id)
        {
            await _repository.Delete<Goods>(id);
        }
    }

}

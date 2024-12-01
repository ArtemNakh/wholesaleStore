using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Interfaces;
using wholesaleStore.Storage;

namespace TicketBookingPlatform.Storage
{
    public class Repository:IRepository
    {
        private readonly wholesaleStoreDBContext _context;

        public Repository(wholesaleStoreDBContext context)
        {
            _context = context;
        }

        public async Task<T> Add<T>(T entity) where T : class
        {
            var obj = _context.Add(entity);
            await _context.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task Delete<T>(int id) where T : class
        {
            var entity =  _context.Set<T>().FindAsync(id).Result;
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public   IQueryable<T> GetAll<T>() where T : class
        {
            return  _context.Set<T>();
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id).AsTask();
        }

        public async Task<IEnumerable<T>> GetQuery<T>(Expression<Func<T, bool>> func) where T : class
        {
            return _context.Set<T>().Where(func);
        }

        public async Task<T> Update<T>(T entity) where T : class
        {
            var newEntity = _context.Update(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}

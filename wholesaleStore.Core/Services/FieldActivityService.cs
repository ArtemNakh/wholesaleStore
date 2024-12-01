
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
    public class FieldActivityService : IFieldActivityService
    {
        private readonly IRepository _repository;

        public FieldActivityService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<FieldActivity> AddFieldActivity(FieldActivity fieldActivity)
        {
            return await _repository.Add(fieldActivity);
        }

        public async Task<FieldActivity> GetFieldActivityById(int id)
        {
            return await _repository.GetById<FieldActivity>(id);
        }

        public async Task<IEnumerable<FieldActivity>> GetAllFieldActivities()
        {
            return await _repository.GetAll<FieldActivity>().ToListAsync();
        }

        public async Task<FieldActivity> UpdateFieldActivity(FieldActivity fieldActivity)
        {
            return await _repository.Update(fieldActivity);
        }

        public async Task DeleteFieldActivity(int id)
        {
            await _repository.Delete<FieldActivity>(id);
        }
    }
}


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
    public class UsersService : IUsersService
    {
        private readonly IRepository _repository;

        public UsersService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AddUser(User user)
        {
            return await _repository.Add(user);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetById<User>(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAll<User>().ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            return await _repository.Update(user);
        }

        public async Task DeleteUser(int id)
        {
            await _repository.Delete<User>(id);
        }

        
    }
}

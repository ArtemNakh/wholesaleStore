
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IUsersService
    {
        Task<User> AddUser(User user);
        Task<User> GetUserById(int id);
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}

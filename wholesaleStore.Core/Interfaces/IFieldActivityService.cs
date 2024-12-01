
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wholesaleStore.Core.Models;

namespace wholesaleStore.Core.Interfaces
{
    public interface IFieldActivityService
    {
        Task<FieldActivity> AddFieldActivity(FieldActivity fieldActivity);
        Task<FieldActivity> GetFieldActivityById(int id);
        Task<IEnumerable<FieldActivity>> GetAllFieldActivities();
        Task<FieldActivity> UpdateFieldActivity(FieldActivity fieldActivity);
        Task DeleteFieldActivity(int id);
    }
}

using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.Data
{
    public class RolesData : IRoleData
    {
        public Task<Task> AddUserToRole(string username, int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Role>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Role> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Insert(Role entity)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Update(int id, Role entity)
        {
            throw new NotImplementedException();
        }
    }
}

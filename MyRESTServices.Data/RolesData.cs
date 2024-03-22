
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain;
using MyRESTServices.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.Data
{
    public class RolesData
    {
        private readonly AppDbContext _context;

        public RolesData(AppDbContext context)
        {
            _context = context;
        }
        //public async Task<Task> AddUserToRole(string username, int roleId)
        //{
        //    try
        //    {
        //        var userRole = new UsersRoles
        //        {
        //            Username = username,
        //            RoleID = roleId
        //        };

        //        _context.UsersRoles.Add(userRole);

        //        int result = await _context.SaveChangesAsync();

        //        if (result != 1)
        //        {
        //            throw new Exception("Data tidak berhasil ditambahkan");
        //        }

        //        return Task.CompletedTask;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException("Kesalahan: " + ex.Message);
        //    }
        //}

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

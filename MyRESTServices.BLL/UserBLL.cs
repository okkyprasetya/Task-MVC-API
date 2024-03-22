using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyRESTServices.BLL.DTOs;
using MyRESTServices.BLL.Interfaces;
using MyRESTServices.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.BLL
{
    public class UserBLL:IUserBLL
    {
        private readonly IUserData _userData;
        private readonly IMapper _mapper;

        public UserBLL(IUserData articleData, IMapper mapper)
        {
            _userData = articleData;
            _mapper = mapper;
        }

        public Task<Task> ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Delete(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDTO>> GetAllWithRoles()
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetUserWithRoles(string username)
        {
            throw new NotImplementedException();
        }

        public Task<Task> Insert(UserCreateDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            var pass = Helper.GetHash(password);
            var loginUser = await _userData.Login(username, pass);
            var loginMap = _mapper.Map<UserDTO>(loginUser);
            return loginMap;
        }

        public Task<UserDTO> LoginMVC(LoginDTO loginDTO)
        {
            throw new NotImplementedException();
        }
    }
}

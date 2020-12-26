using Common.Models.DTO;
using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Contracts
{
    public interface IUserService
    {
        void AddUser(User user);

        void DeleteUser(int UserId);

        Task<List<UserDTO>> GetUserList();

        Task<UserDTO> GetUserById(int UserId);
    }
}

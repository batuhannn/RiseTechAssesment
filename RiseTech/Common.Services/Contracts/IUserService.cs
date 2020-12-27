using Common.Models.DTO;
using Common.Models.ResponseModel;
using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Contracts
{
    public interface IUserService
    {
        Task AddUser(UserDTO user);

        Task DeleteUser(int UserId);

        Task<List<UserDTO>> GetUserList();

        Task<UserDTO> GetUserById(int UserId);

        Task<List<UserWithCommunicationInfoResponseModel>> GetUserWithCommunicationInfos(int userId);
    }
}

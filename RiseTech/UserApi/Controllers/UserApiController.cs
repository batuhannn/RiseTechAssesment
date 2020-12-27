using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.DTO;
using Common.Models.ResponseModel;
using Common.Services.Contracts;
using Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace UserApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<List<UserDTO>> GetUsers()
        {
            return await _userService.GetUserList();
        }

        //[HttpGet ("{userID}")]
        //public async Task<UserDTO> GetUsersById(int userID)
        //{
        //    return await _userService.GetUserById(userID);
        //}

        [HttpGet("{userID}")]
        public async Task<UserWithCommunicationInfoResponseModel> GetUserById(int userID)
        {
            return await _userService.GetUserWithCommunicationInfo(userID);
        }


        [HttpPost]
        public void AddUser(User user)
        {
             _userService.AddUser(user);
        }

        [HttpDelete ("{userID}")]
        public  void DeleteUser(int userID)
        {
            _userService.DeleteUser(userID);
        }
    }
}

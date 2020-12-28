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
        [HttpGet("GetUsers")]
        public async Task<ApiResponseModel<List<UserDTO>>> GetUsers()
        {
            var response = new ApiResponseModel<List<UserDTO>>();
            try
            {
                response.Data = await _userService.GetUserList();
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.AggregatedException.Add(ex.Message);
            }
            return response;
           
        }

        //[HttpGet ("{userID}")]
        //public async Task<UserDTO> GetUsersById(int userID)
        //{
        //    return await _userService.GetUserById(userID);
        //}

        [HttpGet("GetUserById/{userID}")]
        public async Task<ApiResponseModel<List<UserWithCommunicationInfoResponseModel>>> GetUserById(int userID)
        {
            var response = new ApiResponseModel<List<UserWithCommunicationInfoResponseModel>>();
            try
            {
                response.Data = await _userService.GetUserWithCommunicationInfos(userID);
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.AggregatedException.Add(ex.Message);
            }
            return response;
        }


        [HttpPost("AddUser")]
        public async Task<ApiResponseModel> AddUser(UserDTO user)
        {
            var response = new ApiResponseModel();
            try
            {
                await _userService.AddUser(user);
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.AggregatedException.Add(ex.Message);
            }
            return response;
          
        }

        [HttpDelete ("DeleteUser/{userID}")]
        public async Task<ApiResponseModel> DeleteUser(int userID)
        {
            var response = new ApiResponseModel();
            try
            {
                await _userService.DeleteUser(userID);
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.AggregatedException.Add(ex.Message);
            }
            return response;
           
        }
    }
}

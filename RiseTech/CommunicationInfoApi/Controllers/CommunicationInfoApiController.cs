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

namespace CommunicationInfoApi.Controllers
{
    [ApiController]
    [Route("api/CommunicationInfo")]
    public class CommunicationInfoApiController : ControllerBase
    {        
        private readonly ICommunicationInfoService _communicationInfoService;
        public CommunicationInfoApiController(ICommunicationInfoService communicationInfoService)
        {
            _communicationInfoService = communicationInfoService;
        }
        [HttpGet]
        public async Task<ApiResponseModel<List<CommunicationInfoDTO>>> GetCommunicationInfos() 
        {
            var response = new ApiResponseModel<List<CommunicationInfoDTO>>();
            try
            {
                response.Data = await _communicationInfoService.GetCommunicationInfosList();
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
        [HttpDelete("{communicationId}")]

        public async Task<ApiResponseModel> DeleteCommunicationInfos(int communicationId)
        {
            var response = new ApiResponseModel();
            try
            {
                await _communicationInfoService.CommunicationInfosDeleteFromUser(communicationId);
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

        [HttpPost]
        public async Task<ApiResponseModel> AddCommunicationInfo(CommunicationInfo communicationInfo)
        {
            var response = new ApiResponseModel();
            try
            {
                await _communicationInfoService.CommunicationInfosAddToUser(communicationInfo);
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

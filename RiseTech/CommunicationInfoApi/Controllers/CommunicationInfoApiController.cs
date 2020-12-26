using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Models.DTO;
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
        public async Task<List<CommunicationInfoDTO>> GetCommunicationInfos() 
        {
            return await _communicationInfoService.GetCommunicationInfosList();
        }
        [HttpDelete("{communicationId}")]
        public void DeleteCommunicationInfos(int communicationId)
        {
            _communicationInfoService.CommunicationInfosDeleteFromUser(communicationId); ;
        }

        [HttpPost]
        public void AddCommunicationInfo(int userIdToAddInformation , CommunicationInfo communicationInfo)
        {
            _communicationInfoService.CommunicationInfosAddToUser(userIdToAddInformation, communicationInfo);
        }
    }
}

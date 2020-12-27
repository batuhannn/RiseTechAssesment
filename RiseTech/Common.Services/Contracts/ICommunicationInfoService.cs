using Common.Models.DTO;
using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.Contracts
{
    public interface ICommunicationInfoService
    {
        Task CommunicationInfosAddToUser(CommunicationInfo communicationInfo);

        Task CommunicationInfosDeleteFromUser(int communicationInfoId);

        Task<List<CommunicationInfoDTO>> GetCommunicationInfosList();
    }
}

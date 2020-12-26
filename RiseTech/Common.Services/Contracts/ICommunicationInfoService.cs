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
        void CommunicationInfosAddToUser(User user , CommunicationInfo communicationInfo);

        void CommunicationInfosDeleteFromUser(int communicationInfoId);

        Task<List<CommunicationInfoDTO>> GetCommunicationInfosList();
    }
}

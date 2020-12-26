using AutoMapper;
using Common.Models.DTO;
using Common.Services.Contracts;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class CommunicationInfoService : ICommunicationInfoService
    {
        private readonly IMapper _mapper;
        private readonly GuideDbContext _dbContext;
        public CommunicationInfoService(GuideDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public void CommunicationInfosAddToUser(User user, CommunicationInfo communicationInfo)
        {
            try
            {
                var communicationInfoToUpdate = _dbContext.CommunicationInfos.Where(x => x.UserId == user.UserId).FirstOrDefault();

                if (communicationInfoToUpdate == null)
                {
                    _dbContext.CommunicationInfos.Add(communicationInfo);
                }
                else
                {
                    communicationInfoToUpdate.TelephoneNumber = communicationInfo.TelephoneNumber;
                    communicationInfoToUpdate.Mail = communicationInfo.Mail;
                    communicationInfoToUpdate.Location = communicationInfo.Location;
                }
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void CommunicationInfosDeleteFromUser(int communicationInfoId)
        {
            try
            {
                var communicationInfoToDelete = _dbContext.CommunicationInfos.Where(x => x.CommunicationInfoId == communicationInfoId).FirstOrDefault();
                _dbContext.CommunicationInfos.Remove(communicationInfoToDelete);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CommunicationInfoDTO>> GetCommunicationInfosList()
        {
            try
            {
                var response = await _dbContext.CommunicationInfos.ToListAsync();
                return _mapper.Map<List<CommunicationInfoDTO>>(response);

            }
            catch (Exception)
            {

                throw;
            }
       
        }

    
    }
}

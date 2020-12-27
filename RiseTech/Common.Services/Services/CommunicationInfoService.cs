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
        public void CommunicationInfosAddToUser (CommunicationInfo communicationInfo)
        {
            try
            {
                //New communication Info or not?
                var communicationInfoToUpdate = _dbContext.CommunicationInfos.Where(x => x.UserId == communicationInfo.UserId).FirstOrDefault();
                //New communication
                if (communicationInfoToUpdate == null)
                {
                    _dbContext.CommunicationInfos.Add(communicationInfo);
                }

                //Update information.
                else
                {
                    communicationInfoToUpdate.TelephoneNumber = communicationInfo.TelephoneNumber;
                    communicationInfoToUpdate.Mail = communicationInfo.Mail;
                    communicationInfoToUpdate.Longtitude = communicationInfo.Longtitude;
                    communicationInfoToUpdate.Latitude = communicationInfo.Latitude;
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

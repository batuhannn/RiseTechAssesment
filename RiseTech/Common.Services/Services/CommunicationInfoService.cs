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
        public async Task CommunicationInfosAddToUser (CommunicationInfoDTO communicationInfo)
        {
            try
            {
                //New communication Info or not?
                var communicationInfoToUpdate = await _dbContext.CommunicationInfos.Where(x => x.Id == communicationInfo.Id).FirstOrDefaultAsync();
                //New communication
                if (communicationInfoToUpdate == null)
                {
                    await _dbContext.CommunicationInfos.AddAsync(_mapper.Map<CommunicationInfo>(communicationInfo));
                }

                //Update information.
                else
                {
                    communicationInfoToUpdate.MobileNo = communicationInfo.MobileNo;
                    communicationInfoToUpdate.EMail = communicationInfo.EMail;
                    communicationInfoToUpdate.Longtitude = communicationInfo.Longtitude;
                    communicationInfoToUpdate.Latitude = communicationInfo.Latitude;
                }
                await _dbContext.SaveChangesAsync();
                return;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task CommunicationInfosDeleteFromUser(int communicationInfoId)
        {
            try
            {
                var communicationInfoToDelete = await _dbContext.CommunicationInfos.Where(x => x.Id == communicationInfoId).FirstOrDefaultAsync();
                _dbContext.CommunicationInfos.Remove(communicationInfoToDelete);
                await _dbContext.SaveChangesAsync();
                return;
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

using AutoMapper;
using Common.Models.DTO;
using Common.Models.ResponseModel;
using Common.Services.Contracts;
using Core.Data;
using Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly GuideDbContext _dbContext;
        public UserService(GuideDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task AddUser(UserDTO user)
        {
            try
            {   //New user or not?
                var userToUpdate = await _dbContext.Users.Where(x => x.Id == user.Id).FirstOrDefaultAsync();

                // New user
                if (userToUpdate== null)
                {
                    await _dbContext.Users.AddAsync(_mapper.Map<User>(user));
                }

                //Update User
                else
                {
                    userToUpdate.Name = user.Name;
                    userToUpdate.Surname = user.Surname;
                    userToUpdate.CompanyName = user.CompanyName;
                }
                await _dbContext.SaveChangesAsync();
                return;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteUser(int UserId)
        {
            try
            {
                var userToDelete = await _dbContext.Users.Where(x => x.Id == UserId).FirstOrDefaultAsync();
                _dbContext.Users.Remove(userToDelete);
                await _dbContext.SaveChangesAsync();
                return;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserDTO> GetUserById(int UserId)
        {
            try
            {              
                var response = await _dbContext.Users.Where(x => x.Id == UserId).FirstOrDefaultAsync();
                return _mapper.Map<UserDTO>(response);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<UserDTO>> GetUserList()
        {
            try
            {
                var response = await _dbContext.Users.ToListAsync();
                return _mapper.Map<List<UserDTO>>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UserWithCommunicationInfoResponseModel>> GetUserWithCommunicationInfos(int userId)
        {
            try
            {
                List<UserWithCommunicationInfoResponseModel> infosList = new List<UserWithCommunicationInfoResponseModel>();
                UserWithCommunicationInfoResponseModel model = new UserWithCommunicationInfoResponseModel();
                //Find User
                var user = await GetUserById(userId);
                if (user!=null)
                {
                    model.Name = user.Name;
                    model.Surname = user.Surname;
                    model.CompanyName = user.CompanyName;
                    //Find User's Communication Information
                    var communicationInfo = await _dbContext.CommunicationInfos.Where(x => x.UserId == userId).ToListAsync();
                    if (communicationInfo.Count != 0)
                    {
                        foreach (var item in communicationInfo)
                        {
                            model.MobileNo = item.MobileNo;
                            model.EMail = item.EMail;
                            model.Longtitude = item.Longtitude;
                            model.Latitude = item.Latitude;
                            model.Address = item.Address;
                            infosList.Add(model);
                        }

                    }
                    else
                    {
                        infosList.Add(model);
                    }
                 

                }
                return _mapper.Map<List<UserWithCommunicationInfoResponseModel>>(infosList);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


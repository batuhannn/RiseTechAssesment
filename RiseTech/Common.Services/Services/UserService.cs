using AutoMapper;
using Common.Models.DTO;
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
        public void AddUser(User user)
        {
            try
            {
                var userToUpdate = _dbContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefault();

                if (userToUpdate== null)
                {
                    _dbContext.Users.Add(user);
                }
                else
                {
                    userToUpdate.UserName = user.UserName;
                    userToUpdate.UserSurname = user.UserSurname;
                    userToUpdate.CompanyName = user.CompanyName;
                }
                _dbContext.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteUser(int UserId)
        {
            try
            {
                var userToDelete = _dbContext.Users.Where(x => x.UserId == UserId).FirstOrDefault();
                _dbContext.Users.Remove(userToDelete);
                _dbContext.SaveChanges();
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
                var response = await _dbContext.Users.Where(x => x.UserId == UserId).FirstOrDefaultAsync();
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



    }
}


using AutoMapper;
using Common.Models.DTO;
using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Mappings
{
    public class DbMappings : Profile
    {
        public DbMappings() : this("MappingsConfig")
        { }

        public DbMappings(string profileName) : base(profileName)
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CommunicationInfo, CommunicationInfoDTO>().ReverseMap();
        }
  
    }
}

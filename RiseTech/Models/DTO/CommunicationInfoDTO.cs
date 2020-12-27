using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DTO
{
    public class CommunicationInfoDTO
    {
        public int Id { get; set; }
        public int MobileNo { get; set; }

        public string EMail { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }

        public string Address { get; set; }
        public int UserId { get; set; }


    }
}

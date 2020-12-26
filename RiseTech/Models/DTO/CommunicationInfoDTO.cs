using Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.DTO
{
    public class CommunicationInfoDTO
    {
        //public int CommunicationInfoId { get; set; }
        public int TelephoneNumber { get; set; }

        public string Mail { get; set; }

        public string Location { get; set; }

        public string Adress { get; set; }

        public User User { get; set; }
        //public int UserId { get; set; }
    }
}

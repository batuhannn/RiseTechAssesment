﻿using Common.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ResponseModel
{
    public class UserWithCommunicationInfoResponseModel
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string CompanyName { get; set; }
        public int MobileNo { get; set; }

        public string EMail { get; set; }

        public int Longtitude { get; set; }

        public int Latitude { get; set; }

        public string Address { get; set; }

    }
}

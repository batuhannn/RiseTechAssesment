using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Models.ResponseModel
{
    public class ApiResponseModel
    {
        public ApiResponseModel()
        {
            AggregatedException = new List<string>();
        }

        public IList<string> AggregatedException { get; set; }
        public bool IsSuccess { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class ApiResponseModel<T> : ApiResponseModel where T : new()
    {
        public T Data { get; set; }
    }
}

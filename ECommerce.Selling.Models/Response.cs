using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Selling.Models
{
    public class ObjectResponse<T>
    {
        public T DataResponse { get; set; }

        public object DataRequest { get; set; }

        public StatusResponse StatusResponse { get; set; }
    }

    public class StatusResponse
    {
        public string Message { get; set; }

        public string Status { get; set; }
    }
}

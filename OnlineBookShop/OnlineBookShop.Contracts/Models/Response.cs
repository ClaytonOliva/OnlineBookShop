using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OnlineBookShop.Contracts.Models
{
    public class Response<T> where T : class
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "error")]
        public string ExceptionMessage { get; set; }

        [JsonProperty(PropertyName = "success")]
        public bool IsSuccess
        {
            get { return string.IsNullOrWhiteSpace(this.ExceptionMessage); }
            set { }
        }

        [JsonProperty(PropertyName = "msg")]
        public string FrontMessage { get; set; }
    }
}

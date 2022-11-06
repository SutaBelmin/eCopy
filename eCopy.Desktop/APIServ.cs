using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Desktop
{
    public class APIService
    {
        private string _resource = null;
        public string _endpoint = "https://localhost:7284/Employee";

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>()
        {
            var list = await $"{_endpoint}{_resource}".GetJsonAsync<T>();

            return list;
        }
    }
}

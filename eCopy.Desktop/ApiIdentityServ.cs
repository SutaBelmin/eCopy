using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCopy.Model;


namespace eCopy.Desktop
{
    public class ApiIdentityServ
    {
        private string _resource = null;
        public string _endpoint = "https://localhost:7179/";

        public ApiIdentityServ(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search = null)
        {
            var query = "";
            if (search != null)
            {
                query = await search.ToQueryString();
            }

            var list = await $"{_endpoint}{_resource}?{query}".GetJsonAsync<T>();

            return list;
        }

        public async Task<T> Get<T>(string path, object search = null)
        {
            var query = "";
            if (search != null)
            {
                query = await search.ToQueryString();
            }

            var list = await $"{_endpoint}{_resource}/{path}?{query}".GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}{_resource}/{id}".GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            var result = await $"{_endpoint}{_resource}".PostJsonAsync(request).ReceiveJson<T>();

            return result;
        }

        public async Task<T> Put<T>(object id, object request)
        {
            var result = await $"{_endpoint}{_resource}/{id}".PutJsonAsync(request).ReceiveJson<T>();

            return result;
        }
    }
}


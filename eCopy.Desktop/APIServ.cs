using eCopy.Model;
using Flurl.Http;
using System.Threading.Tasks;

namespace eCopy.Desktop
{
    public class APIServ
    {
        private string _resource = null;
        public string _endpoint = "https://localhost:7284/";

        public APIServ(string resource)
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

            var list = await $"{_endpoint}{_resource}?{query}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .GetJsonAsync<T>();

            return list;
        }

        public async Task<T> Get<T>(string path, object search = null)
        {
            var query = "";
            if (search != null)
            {
                query = await search.ToQueryString();
            }

            var list = await $"{_endpoint}{_resource}/{path}?{query}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .GetJsonAsync<T>();

            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}{_resource}/{id}"
                .WithHeader("Authorization", User.Token)
                .GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            var result = await $"{_endpoint}{_resource}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .PostJsonAsync(request)
                .ReceiveJson<T>();

            return result;
        }

        public async Task<T> Put<T>(object id, object request)
        {
            var result = await $"{_endpoint}{_resource}/{id}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .PutJsonAsync(request)
                .ReceiveJson<T>();

            return result;
        }
    }
}

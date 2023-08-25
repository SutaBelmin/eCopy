using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using Flurl.Http;
using System.Collections;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace eCopy.Desktop
{
    public class APIServ
    {
        private string _resource = null;
        public string _endpoint = "http://localhost:5000/";
        //public string _endpoint = "https://localhost:7284/";

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
                .WithHeader("Authorization", $"Bearer {User.Token}")
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

        public async Task Delete(int id)
        {
            var result = await $"{_endpoint}{_resource}/{id}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .DeleteAsync();
                
        }

        public async Task<GetByUsernameOrEmail> GetByUsrnameOrEmail(string username, string email)
        {
            var result = await $"{_endpoint}{_resource}/GetByUsrnameOrEmail?username={username}&email={email}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .GetJsonAsync<GetByUsernameOrEmail>();

            return result;
        }


        public async Task<CityEResponse> CityExist(string name, int postalCode)
        {
            var result = await $"{_endpoint}{_resource}/CityExist?name={name}&postalCode={postalCode}"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .GetJsonAsync<CityEResponse>();

            return result;
        }

        public async Task<EmployeeResponse> GetEmployeeAccount()
        {
            var result = await $"{_endpoint}{_resource}/GetEmployeeAccount"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .GetJsonAsync<EmployeeResponse>();

            return result;
        }

        public async Task<bool> ChangePass(PassRequest request)
        {
            var result = await $"{_endpoint}{_resource}/ChangePass"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .PutJsonAsync(request)
                .ReceiveJson<bool>();

            return result;
        }

        public async Task<EmployeeResponse> UpdateEmp(UpdateEmployeeRequest update)
        {
            var result = await $"{_endpoint}{_resource}/UpdateEmp"
                .WithHeader("Authorization", $"Bearer {User.Token}")
                .PutJsonAsync(update)
                .ReceiveJson<EmployeeResponse>();

            return result;
        }
    }
}

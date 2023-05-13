using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.SearchObjects;

namespace eCopy.Services
{
    public interface IEmployeeService : ICRUDService<EmployeeResponse, EmployeeSearch, EmployeeRequest, EmployeeRequest>
    {

    }
}

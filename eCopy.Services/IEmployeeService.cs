using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;

namespace eCopy.Services
{
    public interface IEmployeeService : ICRUDService<EmployeeResponse, EmployeeSearch, EmployeeRequest, EmployeeRequest>
    {
        bool ChangePass(PassRequest request);

        EmployeeResponse GetEmployeeAccount();

        EmployeeResponse UpdateEmp(UpdateEmployeeRequest update);

        EmployeeResponse UpdateEmpByAdmin(int id, UpdateEmployeeRequest update);

        bool ChangePassByAdmin(int id, PassRequest request);
    }
}

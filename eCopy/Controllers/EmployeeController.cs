using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    [Authorize]
    public class EmployeeController : BaseCRUDController<EmployeeResponse, Employee, EmployeeSearch, EmployeeRequest, EmployeeRequest>
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service) : base(service)
        {
            this.service = service;
        }

        [HttpGet("GetEmployeeAccount")]
        public EmployeeResponse GetEmployeeAccount()
        {
            return service.GetEmployeeAccount();
        }

        [HttpPut("ChangePass")]
        public bool ChangePass(PassRequest request)
        {
            return service.ChangePass(request);
        }

        [HttpPut("UpdateEmp")]
        public EmployeeResponse UpdateEmp(UpdateEmployeeRequest update)
        {
            return service.UpdateEmp(update);
        }

        [HttpPut("UpdateEmpByAdmin/{id}")] 
        public EmployeeResponse UpdateEmpByAdmin(int id, UpdateEmployeeRequest update)
        {
            return service.UpdateEmpByAdmin(id, update);
        }

        [HttpPut("ChangePassByAdmin/{id}")]
        public bool ChangePassByAdmin(int id, PassRequest request)
        {
            return service.ChangePassByAdmin(id, request);
        }
    }
}

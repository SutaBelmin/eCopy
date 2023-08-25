using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
    }
}

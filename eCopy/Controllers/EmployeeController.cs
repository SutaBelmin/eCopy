﻿using eCopy.Model;
using eCopy.Model.Requests;
using eCopy.Model.SearchObjects;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;

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
    }
}

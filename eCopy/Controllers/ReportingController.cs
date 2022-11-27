using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportingController : ControllerBase
    {
        private readonly IReportService reportService;

        public ReportingController(IReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet]
        public IEnumerable<Top5CustomerResponse> GetCustomers()
        {
           return reportService.GetTop5Customer();
        }
    }
}

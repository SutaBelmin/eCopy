using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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

        [HttpGet("[action]")]
        public IEnumerable<RevenueForPeriodResponse> GetRevenueForPeriod(DateTime dateTime1, DateTime dateTime2)
        {
            return reportService.GetRevenueForPeriod(dateTime1, dateTime2);
        }

        [HttpGet("[action]")]
        public IEnumerable<RevenueForLastYearResponse> GetRevenueForLastYear()
        {
            return reportService.GetRevenueForLastYear();
        }
    }
}

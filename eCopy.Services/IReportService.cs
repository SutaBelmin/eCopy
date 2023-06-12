using eCopy.Model.Response;
using System;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IReportService
    {
        IEnumerable<Top5CustomerResponse> GetTop5Customer();
        IEnumerable<RevenueForPeriodResponse> GetRevenueForPeriod(DateTime dateTime1, DateTime dateTime2);
        IEnumerable<RevenueForLastYearResponse> GetRevenueForLastYear();
    }
}

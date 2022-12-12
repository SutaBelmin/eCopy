using eCopy.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public interface IReportService
    {
        IEnumerable<Top5CustomerResponse> GetTop5Customer();

        IEnumerable<RevenueForPeriodResponse> GetRevenueForPeriod(DateTime dateTime1, DateTime dateTime2);
        IEnumerable<RevenueForLastYearResponse> GetRevenueForLastYear();

    }
}

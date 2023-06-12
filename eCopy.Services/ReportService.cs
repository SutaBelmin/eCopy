using AutoMapper;
using eCopy.Model.Enum;
using eCopy.Model.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class ReportService : IReportService
    {
        private readonly eCopyContext context;
        private readonly IMapper mapper;

        public ReportService(eCopyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IEnumerable<Top5CustomerResponse> GetTop5Customer()
        {
            var result = context.Requests
                .Include(x => x.Client)
                .ThenInclude(x => x.Person)
                .Where(x=> x.Status == Status.Completed.ToString())
                .GroupBy(x => new { x.ClientId, x.Client.Person.FirstName, x.Client.Person.LastName, x.Client.Person.Gender })
                .Select(x => new Top5CustomerResponse
                {
                    ClientId = x.Key.ClientId,
                    FirstName = x.Key.FirstName,
                    LastName = x.Key.LastName,
                    Gender = x.Key.Gender,
                    Revenue = x.Sum(y => y.Price)
                })
                .OrderByDescending(x => x.Revenue)
                .Take(5)
                .ToList();

            return result;
        }

        public IEnumerable<RevenueForPeriodResponse> GetRevenueForPeriod(DateTime dateTime1, DateTime dateTime2)
        {
            var result = context.Requests
                .Where(x => x.Status == Status.Completed.ToString() 
                && x.RequestDate > dateTime1 && x.RequestDate < dateTime2)
                .GroupBy(x => new { x.RequestDate.Date })
                .Select(x=> new RevenueForPeriodResponse
                {
                    Date = x.Key.Date,
                    Revenue = x.Sum(y=> y.Price)
                })
                .OrderBy(x=> x.Date) 
                .ToList();

            return result;
        }

        public IEnumerable<RevenueForLastYearResponse> GetRevenueForLastYear()
        {
            DateTime lastYear = DateTime.Now.AddMonths(-12);

            var result = context.Requests
                .Where(x => x.Status == Status.Completed.ToString()
                && x.RequestDate >= lastYear)
                .GroupBy(x => new { x.RequestDate.Month })
                .Select(x => new RevenueForLastYearResponse
                { 
                   Date = x.Key.Month,
                   Revenue = x.Sum(y => y.Price)
                })
                .OrderBy(x => x.Date)
                .ToList();

            return result;
        }
    }
}

using AutoMapper;
using eCopy.Model.Enum;
using eCopy.Model.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Revenue = x.Sum(x => x.Price)
                })
                .OrderByDescending(x => x.Revenue)
                .Take(5)
                .ToList();

            return result;
        }
    }
}

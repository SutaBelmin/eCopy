using AutoMapper;
using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PracticeController
    {
        protected readonly eCopyContext context;
        protected readonly IMapper mapper;

        public PracticeController(eCopyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<PrintRequestR> GetAllReq()
        {
            var entity = context.Requests.AsQueryable();

            var list = entity.ToList();

            return mapper.Map<IList<PrintRequestR>>(list);
        }
    }
}

using eCopy.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace eCopy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        private readonly IService<T, TSearch> service;

        public BaseController(IService<T, TSearch> service)
        {
            this.service = service;
        }

        [HttpGet]
        public virtual IEnumerable<T> Get([FromQuery] TSearch search)
        {
            var user = User;
            return service.Get(search);
        }

        [HttpGet("{id}")]
        public virtual T GetById(int id)
        {
            return service.GetById(id);
        }
    }
}

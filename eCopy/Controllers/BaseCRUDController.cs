using eCopy.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCopy.Controllers
{
    public abstract class BaseCRUDController<T, TDb, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
        where T : class where TSearch : class where TInsert : class where TUpdate : class
    {
        private readonly ICRUDService<T, TSearch, TInsert, TUpdate> service;

        public BaseCRUDController(ICRUDService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            this.service = service;
        }

        [HttpPost]
        public virtual T Insert ([FromBody]TInsert insert)
        {
            var result = service.Insert(insert);

            return result;
        }

        [HttpPut("{id}")]
        public virtual T Update(int id, [FromBody] TUpdate update)
        {
            var result = service.Update(id, update);

            return result;
        }
    }
}

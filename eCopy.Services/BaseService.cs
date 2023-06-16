using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{
    public class BaseService<T, TDb, TSearch> : IService<T, TSearch>
        where T : class where TDb : class where TSearch : class
    {
        protected readonly eCopyContext context;
        protected readonly IMapper mapper;

        public BaseService(eCopyContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var entity = context.Set<TDb>().AsQueryable();


            var list = entity.ToList();
            
            return mapper.Map<IList<T>>(list);
        }

        public virtual IQueryable<TDb> AddFilter(IQueryable<TDb> query , TSearch search = null)
        {
            return query;
        }

        public virtual T GetById(int id)
        {
            var set = context.Set<TDb>();

            var entity = set.Find(id);

            return mapper.Map<T>(entity);
        }
    }
}

using AutoMapper;
using System.Threading.Tasks;
using System;

namespace eCopy.Services
{
    public class BaseCRUDService<T, TDb, TSearch, TInsert, TUpdate> : BaseService<T, TDb, TSearch>, ICRUDService<T, TSearch, TInsert, TUpdate>
            where T : class where TDb : class where TSearch : class where TInsert : class where TUpdate : class
    {
        public BaseCRUDService(eCopyContext context, IMapper mapper) :base(context, mapper)
        {

        }
        public virtual T Insert(TInsert insert)
        {
           var set = context.Set<TDb>();

            TDb entity = mapper.Map<TDb>(insert);

            set.Add(entity);

            context.SaveChanges();

            return mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate update)
        {
            var set = context.Set<TDb>();

            var entity = set.Find(id);

            if(entity != null)
            {
                mapper.Map(update,entity);
            }
            else
            {
                return null;
            }

            context.SaveChanges();

            return mapper.Map<T>(entity);

        }

        
        public virtual void Delete(int id)
        {
            TDb model =  context.Set<TDb>().Find(id);
            try
            {
                context.Set<TDb>().Remove(model);
                context.SaveChanges();
               
            }
            catch (Exception e)
            {
               
                throw e;
            }
        }
    }
}

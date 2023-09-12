using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Linq;

namespace eCopy.Services
{
    public class CityService : BaseCRUDService<CityResponse, City, CitySearch, CityRequest, CityRequest>, ICityService
    {
        public CityService(eCopyContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }

        public override CityResponse Update(int id, CityRequest update)
        {
            var city = context.Cities.Find(id);

            city.Name= update.Name;
            city.ShortName= update.ShortName;
            city.PostalCode= update.PostalCode;
            city.CountryId = 1;
            city.Active = update.Active;

            context.SaveChanges();

            return mapper.Map<CityResponse>(city);
        }

        public CityEResponse CityExist(string name, int postalCode)
        {
            var cityName = context.Cities.FirstOrDefault(x => x.Name == name);

            var posCode = context.Cities.FirstOrDefault(x => x.PostalCode == postalCode);

            return new CityEResponse
            {
                Name = cityName != null,
                PostalCode = posCode != null
            };
        }

    }
}

using AutoMapper;
using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using eCopy.Services.Database;
using System.Collections.Generic;
using System.Linq;

namespace eCopy.Services
{

    public class LetterService : BaseCRUDService<LetterResponse, Letter, LetterSearch, LetterRequest, LetterRequestUpdate>, ILetterService
    {
        public LetterService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {

        }

        public List<LetterResponse> GetActive()
        {
            var list = context.Letter.Where(x => x.IsActive == true).ToList();

            return mapper.Map<List<LetterResponse>>(list);
        }

    }
}

using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface ILetterService : ICRUDService<LetterResponse, LetterSearch, eCopy.Model.Requests.LetterRequest, eCopy.Model.Requests.LetterRequestUpdate>
    {
        List<LetterResponse> GetActive();
    }
}

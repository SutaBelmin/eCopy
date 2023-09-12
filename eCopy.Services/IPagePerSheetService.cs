using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IPagePerSheetService : ICRUDService<PagePerSheetResponse, PagePerSheetSearch, eCopy.Model.Requests.PagePerSheetRequest, eCopy.Model.Requests.PagePerSheetRequestUpdate>
    {
        List<PagePerSheetResponse> GetActive();
    }
}

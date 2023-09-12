using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IPrintPageOptService : ICRUDService<PrintPageOptionResponse, PrintPageOptionSearch, eCopy.Model.Requests.PrintPageOptionRequest, eCopy.Model.Requests.PrintPageOptionRequestUpdate>
    {
        List<PrintPageOptionResponse> GetActive();
    }
}

using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System.Collections.Generic;

namespace eCopy.Services
{
    public interface IPrintRequestService : ICRUDService<PrintRequestR, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>

    {
        IEnumerable<PrintRequestR> GetAllR();
        PrintRequestR Pay(int id);
        PrintRequestR UpdateRequest(int id, UpdateRequest update);
        void CancelRequest(int id);

    }
}

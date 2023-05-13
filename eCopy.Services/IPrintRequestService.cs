using eCopy.Model.Requests;
using eCopy.Model.Response;
using eCopy.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public interface IPrintRequestService : ICRUDService<PrintRequestR, PrintRequestSearch, eCopy.Model.Requests.PrintRequest, eCopy.Model.Requests.PrintRequestUpdate>

    {
        IEnumerable<PrintRequestR> GetAllR();
        
    }
}

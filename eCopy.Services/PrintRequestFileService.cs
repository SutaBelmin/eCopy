using AutoMapper;
using eCopy.Model.Response;
using System;

namespace eCopy.Services
{
    public class PrintRequestFileService : BaseCRUDService<PrintRequestFileR, PrintRequestFile, Object, eCopy.Model.Requests.PrintRequestFile, eCopy.Model.Requests.PrintRequestFile>, IPrintRequestFileService
    {
        public PrintRequestFileService(eCopyContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}

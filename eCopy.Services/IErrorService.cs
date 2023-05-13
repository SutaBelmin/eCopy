using eCopy.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services
{
    public interface IErrorService
    {
        void AddError(ErrorRequest request);
    }
}

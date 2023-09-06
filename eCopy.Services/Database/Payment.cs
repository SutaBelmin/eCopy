using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCopy.Services.Database
{
    public class Payment
    {
        public int Id { get; set; }
        public string StripePaymentId { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }

        public int RequestId { get; set; }
        public Request Request { get; set; }

    }
}

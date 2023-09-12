using System;

namespace eCopy.Model.Response
{
    public class PaymentResponse
    {
        public string StripePaymentId { get; set; }
        public DateTime Created { get; set; }
        public decimal Amount { get; set; }
    }
}

using eCopy.Model.Enum;
using System.Collections.Generic;

namespace eCopy.Desktop
{
    public class StatusStateMachine
    {
        public static List<Status> GetState(Status currentStatus)
        {
            if(currentStatus == Status.New)
            {
                return new List<Status>
                {
                    Status.New,
                    Status.OnHold,
                    Status.InProgress,
                    Status.AwaitingPayment,
                    Status.Completed,
                    Status.Rejected,
                    Status.Canceled,
                    Status.Updated
                };
            }
            if (currentStatus == Status.OnHold)
            {
                return new List<Status>
                {
                    Status.OnHold,
                    Status.InProgress,
                    Status.AwaitingPayment,
                    Status.Completed,
                    Status.Rejected,
                    Status.Canceled,
                    Status.Updated
                };
            }
            if (currentStatus == Status.InProgress)
            {
                return new List<Status>
                {
                    Status.InProgress,
                    Status.OnHold,
                    Status.AwaitingPayment,
                    Status.Completed,
                    Status.Rejected,
                    Status.Canceled,
                    Status.Updated
                };
            }
            if (currentStatus == Status.AwaitingPayment)
            {
                return new List<Status>
                {
                    Status.AwaitingPayment,
                    Status.Completed,
                    Status.Rejected,
                    Status.Canceled
                };
            }
            if (currentStatus == Status.Completed)
            {
                return new List<Status>
                {
                   Status.Completed
                };
            }
            if (currentStatus == Status.Rejected)
            {
                return new List<Status>
                {
                   Status.Rejected
                };
            }
            if (currentStatus == Status.Canceled)
            {
                return new List<Status>
                {
                   Status.Canceled
                };
            }
            if (currentStatus == Status.Updated)
            {
                return new List<Status>
                {
                   Status.Updated,
                   Status.InProgress,
                   Status.OnHold,
                   Status.AwaitingPayment,
                   Status.Completed,
                   Status.Rejected,
                   Status.Canceled,
                };
            }
            return new List<Status>();
        }
    }
}

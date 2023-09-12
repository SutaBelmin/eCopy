
namespace eCopy.Model.Enum
{

    public enum Role
    {
        Administrator = 1,
        Company = 2,
        Copier = 3,
        Employee = 4,
        User = 5
    }

    public enum Status
    {
        New = 1,
        OnHold = 2,
        InProgress = 3,
        AwaitingPayment = 4,
        Completed = 5,
        Rejected = 6,
        Canceled = 7,
        Updated = 8
    }

    public enum Gender
    {
        Male,
        Female
    }
}

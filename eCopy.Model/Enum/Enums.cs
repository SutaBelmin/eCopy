
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

    public enum PrintPagesOptions
    {
        All = 1,
        Even = 2,
        Odd = 3,
        Custom = 4
    }

    public enum SidePrintOption
    {
        PrintOneSided = 1,
        PrintBothSides = 2
    }

    public enum Orientation
    {
        Portrait = 1,
        Landscape = 2
    }

    public enum Letter
    {
        A1 = 1,
        A2 = 2,
        A3 = 3,
        A4 = 4,
        A5 = 5,
        A6 = 6
    }

    public enum PagePerSheet
    {
        OnePage = 1,
        TwoPages = 2
    }

    public enum CollatedPrintOptions
    {
        Collated = 1,
        Uncollated = 2
    }

    public enum Gender
    {
        Male,
        Female
    }
}

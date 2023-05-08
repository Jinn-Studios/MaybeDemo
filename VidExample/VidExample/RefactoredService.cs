namespace VidExample;
using VidExample.Core;
using VidExample.Data.Core;
using VidExample.Data.Entities;

public class RefactoredService : IContract
{
    private readonly IRepo _repo;

    public RefactoredService(IRepo repo)
    {
        _repo = repo;
    }

    public string DoThings(int itemId)
    {
        SomeEntity thing;
        try
        {
            thing = _repo.GetItem(itemId);
            if (thing == null) return null;
        }
        catch (Exception)
        {
            // Perhaps special domain level handling.
            return null;
        }

        var xfmNum = ValidateNum(thing.NumOrSomething);
        var xfmDate = ValidateDate(thing.SomeDateTime);
        var year = thing.SomeDateTime.Value.Year;

        return FinalizeDoThings(year, xfmNum, xfmDate);
    }

    internal static string FinalizeDoThings(int year, int xfmNum, string xfmDate)
    {
        int calc = (year - 2000) / (year < 2000 ? 1 : xfmNum);
        return xfmDate + " = " + calc;
    }

    internal static int ValidateNum(int? num)
    {
        if (false == num.HasValue)
            throw new Exception("No Num");

        if (num == 0)
            throw new Exception("Can't divide by Zero");

        return num.Value;
    }

    internal static string ValidateDate(DateTime? dt)
    {
        if (false == dt.HasValue)
            throw new Exception("No SomeDate");

        if (dt.Value.Year >= 2000)
            return "Within Century";
        else
            return "Last Century";
    }
}
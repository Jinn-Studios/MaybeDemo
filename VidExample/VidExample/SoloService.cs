namespace VidExample;
using VidExample.Core;
using VidExample.Data.Core;
using VidExample.Data.Entities;

public class SoloService : IContract
{
    private readonly IRepo _repo;

    public SoloService(IRepo repo)
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

        if (false == thing.NumOrSomething.HasValue)
            return "No Num";

        if (thing.NumOrSomething == 0)
            throw new Exception("Can't divide by Zero");

        int xfmNum = thing.NumOrSomething.Value;

        string xfmDate;
        if (false == thing.SomeDateTime.HasValue)
            return "No SomeDate";

        if (thing.SomeDateTime.Value.Year >= 2000)
            xfmDate = "Within Century";
        else
            xfmDate = "Last Century";

        var year = thing.SomeDateTime.Value.Year;

        int calc = (year - 2000) / (year < 2000 ? 1 : xfmNum);
        return xfmDate + " = " + calc;
    }
}
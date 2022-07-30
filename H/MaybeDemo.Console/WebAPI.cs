using JinnDev.Utilities.Monad;
using System;

public class WebAPIController
{
    private readonly IService _svc;

    public WebAPIController(IService svc)
    {
        _svc = svc;
    }

    /*GET => /api/Person/{id:int}/MiddleName*/
    public string GetMiddleName(int id)
    {
        var middleName = _svc.GetMiddleNameForPerson(id);
        ValidateMiddleName(middleName);
        return middleName.Value;
    }

    private static void ValidateMiddleName(Maybe<string> middleName)
    {
        middleName.MatchT(
            x => Console.WriteLine("MiddleName Len: " + x.Length),
            x => Console.WriteLine(x.Message)
        );

        Console.WriteLine("MiddleName: " + (middleName.Value ?? "`null`"));
    }
}
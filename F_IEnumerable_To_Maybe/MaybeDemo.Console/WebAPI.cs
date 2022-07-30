using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        var mnEnumerable = _svc.GetMiddleNameForPerson(id);
        ValidateMiddleName(mnEnumerable);
        return mnEnumerable.FirstOrDefault();
    }

    private static void ValidateMiddleName(IEnumerable<string> maybeMiddleName)
    {
        if (maybeMiddleName.Any() == false)
            Console.WriteLine("MiddleName has no length, it is null");
        else
            Console.WriteLine("MiddleName Len: " + maybeMiddleName.Single().Length);
        Console.WriteLine("MiddleName: " + (maybeMiddleName.SingleOrDefault() ?? "`null`"));
    }
}
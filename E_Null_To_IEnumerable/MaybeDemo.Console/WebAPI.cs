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
        var hasValue = _svc.TryGetMiddleNameForPerson(id, out string middleName);
        ValidateMiddleName(middleName, hasValue);
        return middleName;
    }

    private static void ValidateMiddleName(string middleName, bool hasValue)
    {
        if (hasValue == false)
            Console.WriteLine("MiddleName has no length, it is null");
        else
            Console.WriteLine("MiddleName Len: " + middleName.Length);
        Console.WriteLine("MiddleName: " + (middleName ?? "`null`"));
    }
}
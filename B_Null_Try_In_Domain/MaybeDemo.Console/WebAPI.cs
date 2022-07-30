﻿using System;

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
        return middleName;
    }

    private static void ValidateMiddleName(string middleName)
    {
        if (middleName == null)
            Console.WriteLine("MiddleName has no length, it is null");
        else
            Console.WriteLine("MiddleName Len: " + middleName.Length);
        Console.WriteLine("MiddleName: " + (middleName ?? "`null`"));
    }
}
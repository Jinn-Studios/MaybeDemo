using System.Collections.Generic;

public static class FunExt
{
    public static void Add(this List<PersonEntity> lst, string f, string m, string l)
    {
        lst.Add(new PersonEntity
        {
            Id = lst.Count + 1,
            FirstName = f,
            MiddleName = m,
            LastName = l
        });
    }
}
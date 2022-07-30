using System;
using System.Collections.Generic;
using System.Linq;

public class PersonRepo : IPersonRepo
{
    private readonly List<PersonEntity> _ppl;

    public PersonRepo(List<PersonEntity> ppl)
    {
        _ppl = ppl;
    }

    public bool TryGetPersonById(int personId, out PersonEntity person)
    {
        person = null;
        try
        {
            person = _ppl.Single(x => x.Id == personId);
            return true;
        }
        catch { }
        return false;
    }
}
using JinnDev.Utilities.Monad;
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

    public Maybe<PersonEntity> GetPersonById(int personId)
    {
        try
        {
            return Maybe.Some(_ppl.Single(x => x.Id == personId));
        }
        catch (Exception ex)
        {
            return Maybe.None<PersonEntity>(ex, "Person Doesn't Exist With ID: " + personId);
        }
    }
}
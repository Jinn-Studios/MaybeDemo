using System.Collections.Generic;
using System.Linq;

public class PersonRepo : IPersonRepo
{
    private readonly List<PersonEntity> _ppl;

    public PersonRepo(List<PersonEntity> ppl)
    {
        _ppl = ppl;
    }

    public PersonEntity GetPersonById(int personId)
    {
        return _ppl.Single(x => x.Id == personId);
    }
}
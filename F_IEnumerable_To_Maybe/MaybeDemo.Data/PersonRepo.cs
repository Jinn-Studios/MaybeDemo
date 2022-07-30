using System.Collections.Generic;
using System.Linq;

public class PersonRepo : IPersonRepo
{
    private readonly List<PersonEntity> _ppl;

    public PersonRepo(List<PersonEntity> ppl)
    {
        _ppl = ppl;
    }

    public IEnumerable<PersonEntity> GetPersonById(int personId)
    {
        var result = new List<PersonEntity>();
        try
        {
            result.Add(_ppl.Single(x => x.Id == personId));
        }
        catch { }
        return result;
    }
}
using System.Collections.Generic;
using System.Linq;

public partial class PersonService : IService
{
    private readonly IPersonRepo _repo;

    public PersonService(IPersonRepo repo)
    {
        _repo = repo;
    }

    public IEnumerable<string> GetMiddleNameForPerson(int personId)
        => _repo.GetPersonById(personId)
            .Where(x => !string.IsNullOrWhiteSpace(x.MiddleName))
            .Select(x => x.MiddleName);
}
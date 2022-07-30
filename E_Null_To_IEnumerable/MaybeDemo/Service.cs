public partial class PersonService : IService
{
    private readonly IPersonRepo _repo;

    public PersonService(IPersonRepo repo)
    {
        _repo = repo;
    }

    public bool TryGetMiddleNameForPerson(int personId, out string middleName)
    {
        middleName = null;
        var success = _repo.TryGetPersonById(personId, out PersonEntity person);
        if (success == false || string.IsNullOrWhiteSpace(person.MiddleName))
            return false;

        middleName = person.MiddleName;
        return true;
    }
}
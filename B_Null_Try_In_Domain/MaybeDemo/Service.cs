public partial class PersonService : IService
{
    private readonly IPersonRepo _repo;

    public PersonService(IPersonRepo repo)
    {
        _repo = repo;
    }

    public string GetMiddleNameForPerson(int personId)
    {
        var person = _repo.GetPersonById(personId);
        return person.MiddleName;
    }
}
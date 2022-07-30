using JinnDev.Utilities.Monad;

public partial class PersonService : IService
{
    private readonly IPersonRepo _repo;

    public PersonService(IPersonRepo repo)
    {
        _repo = repo;
    }

    public Maybe<string> GetMiddleNameForPerson(int personId)
        => _repo.GetPersonById(personId).Match(
            x => { return GetMiddleNameForPerson(x); },
            x => { return x.AsGeneric<string>(); }
        );

    private static Maybe<string> GetMiddleNameForPerson(PersonEntity person)
    {
        if (string.IsNullOrWhiteSpace(person.MiddleName))
            return Maybe.None<string>("Person has no MiddleName");
        return person.MiddleName;
    }
}
using JinnDev.Utilities.Monad;

public partial class PersonService : IService
{
    private readonly IPersonRepo _repo;

    public PersonService(IPersonRepo repo)
    {
        _repo = repo;
    }

    public Maybe<string> GetMiddleNameForPerson(int personId)
    {
        var person = _repo.GetPersonById(personId);

        if (person.HasValue == false)
        {
            if (person.IsExceptionState)
                throw person.Exception;

            return person.AsGeneric<string>();
        }

        return GetMiddleNameForPerson(person.Value);
    }
    //=> _repo.GetPersonById(personId).MatchT(
    //    x => GetMiddleNameForPerson(x),
    //    x => x.AsGeneric<string>());

    private static Maybe<string> GetMiddleNameForPerson(PersonEntity person)
    {
        if (string.IsNullOrWhiteSpace(person.MiddleName))
            return ReParseMiddleNameFromFullName(person.FullNameRaw);
        return person.MiddleName;
    }

    private static Maybe<string> ReParseMiddleNameFromFullName(string fullName)
    {
        var parts = fullName.Split(new string[] { " " }, System.StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 3)
            return parts[1];
        return Maybe.None<string>("Person has no MiddleName");
    }
}
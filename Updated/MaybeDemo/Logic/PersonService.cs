namespace MaybeDemo;
using JinnDev.Utilities.Monad;
using MaybeDemo.Data.Entities;

public partial class PersonService
{
    internal static Maybe<string> GetMiddleNameFromPerson(PersonEntity? person)
    {
        if (person == null)
            return Maybe.None<string>("Person was null");

        if (false == string.IsNullOrWhiteSpace(person.MiddleName))
            return Maybe.Some(person.MiddleName);

        if (string.IsNullOrWhiteSpace(person.FullNameRaw))
            return Maybe.None<string>("No MiddleName or FullName");

        var parts = person.FullNameRaw.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 3)
            return Maybe.None<string>("FullName could not be split to recognize where the MiddleName is");

        return parts[1];
    }

    internal static Maybe<string> ProperNounCasing(string? middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName)) return Maybe.None<string>("No MiddleName to Case");
        return Maybe.Some(string.Concat(char.ToUpper(middleName[0]), middleName[1..]));
    }
}
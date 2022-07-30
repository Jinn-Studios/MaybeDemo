using JinnDev.Utilities.Monad;
using MaybeDemo.Data.Entities;

namespace MaybeDemo
{
    public partial class PersonService
    {
        public static Maybe<string> MaybeMiddleName(PersonEntity? person)
            => string.IsNullOrWhiteSpace(person?.MiddleName) == false
                ? person.MiddleName
                : ReParseMiddleNameFromFullName(person?.FullNameRaw);

        public static Maybe<string> ReParseMiddleNameFromFullName(string? fullName)
        {
            if (fullName != null)
            {
                var parts = fullName.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 3)
                    return parts[1];
            }

            return Maybe.None<string>("Could not parse a middle name.");
        }
    }
}
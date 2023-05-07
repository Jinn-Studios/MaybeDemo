namespace MaybeDemo.Core;
using JinnDev.Utilities.Monad;

public interface IPersonService
{
    Maybe<string> GetMiddleNameForPerson(int personId);
}
using JinnDev.Utilities.Monad;

namespace MaybeDemo.Core
{
    public interface IPersonService
    {
        Maybe<string> GetMiddleNameForPerson(int personId);
    }
}
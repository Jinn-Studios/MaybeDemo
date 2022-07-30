using JinnDev.Utilities.Monad;

public interface IService
{
    Maybe<string> GetMiddleNameForPerson(int personId);
}
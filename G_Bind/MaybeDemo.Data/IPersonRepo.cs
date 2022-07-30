using JinnDev.Utilities.Monad;

public interface IPersonRepo
{
    Maybe<PersonEntity> GetPersonById(int personId);
}
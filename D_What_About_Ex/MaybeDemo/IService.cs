public interface IService
{
    bool TryGetMiddleNameForPerson(int personId, out string middleName);
}
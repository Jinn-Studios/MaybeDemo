public interface IPersonRepo
{
    bool TryGetPersonById(int personId, out PersonEntity person);
}
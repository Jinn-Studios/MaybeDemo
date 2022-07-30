using System.Collections.Generic;

public interface IService
{
    IEnumerable<string> GetMiddleNameForPerson(int personId);
}
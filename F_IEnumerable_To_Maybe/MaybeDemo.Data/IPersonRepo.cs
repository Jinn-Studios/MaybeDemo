using System.Collections.Generic;

public interface IPersonRepo
{
    IEnumerable<PersonEntity> GetPersonById(int personId);
}
using JinnDev.Utilities.Monad;
using MaybeDemo.Data.Entities;

namespace MaybeDemo.Data.Core
{
    public interface IPersonRepo
    {
        Maybe<PersonEntity> GetPersonById(int personId);
    }
}
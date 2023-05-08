using JinnDev.Utilities.Monad;
using VidExample.Data.Entities;

namespace VidExample.Data.Core
{
    public interface IRepo
    {
        SomeEntity GetItem(int itemId);
    }

    public interface IMaybeRepo
    {
        Maybe<SomeEntity> MaybeGetItem(int itemId);
    }
}
using JinnDev.Utilities.Monad;
using VidExample.Data.Core;
using VidExample.Data.Entities;

namespace VidExample.Data
{
    public class SomeMaybeRepo : IMaybeRepo
    {
        private readonly List<SomeEntity> _dataSource;

        public SomeMaybeRepo(List<SomeEntity> dataSrc)
        {
            _dataSource = dataSrc;
        }

        public Maybe<SomeEntity> MaybeGetItem(int itemId)
            => Maybe.Try(
                   () => Maybe.Some(_dataSource.Single(x => x.Id == itemId)),
                   none => none.Message = "Person Doesn't Exist With ID: " + itemId);
    }
}
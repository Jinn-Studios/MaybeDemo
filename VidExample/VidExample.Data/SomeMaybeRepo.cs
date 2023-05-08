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
            => Maybe.Try(() => GetItem(itemId),
                       none => none.Message = "Person Doesn't Exist With ID: " + itemId);

        private Maybe<SomeEntity> GetItem(int itemId)
        {
            var something = _dataSource.Where(x => x.Id == itemId);
            something = something.Where(x => x.SomeStringVal == null || x.SomeStringVal == "" || x.SomeStringVal != null);
            var result = something.SingleOrDefault(x => x.Id == itemId);

            if (result == null)
            {
                // Handle here, rollback, log, etc
                return Maybe.None<SomeEntity>("Something Not Found");
            }

            return Maybe.Some(result);
        }
    }
}
using JinnDev.Utilities.Monad;
using VidExample.Data.Core;
using VidExample.Data.Entities;

namespace VidExample.Data
{
    public class SomeRepo : IRepo, IMaybeRepo
    {
        private readonly List<SomeEntity> _dataSource;

        public SomeRepo(List<SomeEntity> dataSrc)
        {
            _dataSource = dataSrc;
        }

        public SomeEntity GetItem(int itemId)
        {
            try
            {
                return _dataSource.Single(x => x.Id == itemId);
            }
            catch (Exception)
            {
                // Handle here, rollback, log, etc
                throw; // Or return null?
            }
        }

        public Maybe<SomeEntity> MaybeGetItem(int itemId)
            => Maybe.Try<SomeEntity>(
                   () => _dataSource.Single(x => x.Id == itemId),
                   none => none.Message = "Person Doesn't Exist With ID: " + itemId
               );
    }
}
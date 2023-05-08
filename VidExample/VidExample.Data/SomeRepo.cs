using VidExample.Data.Core;
using VidExample.Data.Entities;

namespace VidExample.Data
{
    public class SomeRepo : IRepo
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
                var something = _dataSource.Where(x => x.Id == itemId);
                something = something.Where(x => x.SomeStringVal == null || x.SomeStringVal == "" || x.SomeStringVal != null);
                var result = something.SingleOrDefault(x => x.Id == itemId);
                if (result == null)
                {
                    // Handle here, rollback, log, etc
                    return null; // Or throw?  return new SomeEntity { Id = 0 }??
                }
                return result;
            }
            catch (Exception)
            {
                // Handle here, rollback, log, etc
                throw; // Or return null?
            }
        }
    }
}
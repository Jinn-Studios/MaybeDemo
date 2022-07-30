using JinnDev.Utilities.Monad;
using MaybeDemo.Data.Core;
using MaybeDemo.Data.Entities;

namespace MaybeDemo.Data
{
    public class PersonRepo : IPersonRepo
    {
        private readonly List<PersonEntity> _ppl;

        public PersonRepo(List<PersonEntity> ppl)
        {
            _ppl = ppl;
        }

        public Maybe<PersonEntity> GetPersonById(int personId)
        {
            try
            {
                return _ppl.Single(x => x.Id == personId);
            }
            catch (Exception ex)
            {
                return Maybe.None<PersonEntity>(ex, "Person Doesn't Exist With ID: " + personId);
            }
        }
    }
}
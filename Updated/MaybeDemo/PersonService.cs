using JinnDev.Utilities.Monad;
using MaybeDemo.Core;
using MaybeDemo.Data.Core;

namespace MaybeDemo
{
    public partial class PersonService : IPersonService
    {
        private readonly IPersonRepo _repo;

        public PersonService(IPersonRepo repo)
        {
            _repo = repo;
        }

        public Maybe<string> GetMiddleNameForPerson(int personId)
            => _repo.GetPersonById(personId)
                .Match(some: MaybeMiddleName, 
                       none: MaybeTransform.Map<string>);
    }
}
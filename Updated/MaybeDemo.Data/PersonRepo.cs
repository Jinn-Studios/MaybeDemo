﻿using JinnDev.Utilities.Monad;
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
            => Maybe.Try<PersonEntity>(
                   () => _ppl.Single(x => x.Id == personId),
                   none => none.Message = "Person Doesn't Exist With ID: " + personId
               );
    }
}
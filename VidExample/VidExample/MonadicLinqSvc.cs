namespace VidExample;
using JinnDev.Utilities.Monad;
using VidExample.Data.Core;

public class MonadicLinqSvc : IMaybeContract
{
    private readonly IMaybeRepo _mRepo;

    public MonadicLinqSvc(IMaybeRepo repo)
    {
        _mRepo = repo;
    }

    public Maybe<string> DoThingsMonadic(int itemId)
        => _mRepo.MaybeGetItem(itemId)
            .Bind(thing => FC.ValidateNum(thing.NumOrSomething)
              .Bind(num => FC.ValidateDate(thing.SomeDateTime)
                .Bind(dt => Maybe.Try(() => Maybe.Some(thing.SomeDateTime.Value.Year))
                  .Bind(yr => FC.FinalizeDoThings(yr, num, dt)))));
}
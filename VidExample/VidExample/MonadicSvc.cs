namespace VidExample;
using JinnDev.Utilities.Monad;
using VidExample.Data.Core;

public class MonadicSvc : IMaybeContract
{
    private readonly IMaybeRepo _mRepo;

    public MonadicSvc(IMaybeRepo repo)
    {
        _mRepo = repo;
    }

    public Maybe<string> DoThingsMonadic(int itemId)
    {
        var thing = _mRepo.MaybeGetItem(itemId);
        var xfmNum = thing.Bind(x => FC.ValidateNum(x.NumOrSomething));
        var xfmDate = thing.Bind(x => FC.ValidateDate(x.SomeDateTime));
        var year = thing.Bind(x => Maybe.Try(() => Maybe.Some(x.SomeDateTime.Value.Year)));

        return from yr in year
               from num in xfmNum
               from dt in xfmDate
               select FC.FinalizeDoThings(yr, num, dt).Value;
    }
}

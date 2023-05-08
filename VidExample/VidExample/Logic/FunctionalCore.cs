namespace VidExample;
using JinnDev.Utilities.Monad;

public class FC
{
    internal static Maybe<int> ValidateNum(int? num)
    {
        if (false == num.HasValue)
            return Maybe.None<int>("No Num");

        if (num == 0)
            return Maybe.None<int>("Can't divide by Zero");

        return Maybe.Some(num.Value);
    }

    internal static Maybe<string> ValidateDate(DateTime? dt)
    {
        if (false == dt.HasValue)
            return Maybe.None<string>("No SomeDate");

        if (dt.Value.Year >= 2000)
            return Maybe.Some("Within Century");
        else
            return Maybe.Some("Last Century");
    }

    internal static Maybe<string> FinalizeDoThings(int year, int xfmNum, string xfmDate)
    {
        int calc = (year - 2000) / (year < 2000 ? 1 : xfmNum);
        return Maybe.Some($"{xfmDate} = {calc}");
    }
}
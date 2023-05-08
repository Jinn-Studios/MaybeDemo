namespace VidExample;
using JinnDev.Utilities.Monad;

public interface IMaybeContract
{
    Maybe<string> DoThingsMonadic(int itemId);
}

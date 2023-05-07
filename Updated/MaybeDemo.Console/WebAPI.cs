using JinnDev.Utilities.Monad;
using MaybeDemo.Core;

namespace MaybeDemo.API
{
    public class WebAPIController // : ControllerBase ... but not really
    {
        private readonly IPersonService _svc;

        public WebAPIController(IPersonService svc)
        {
            _svc = svc;
        }

        // [HttpGet("...")] Imagine this is an API endpoint
        /*GET => /api/Person/{id:int}/MiddleName*/
        public Maybe<string> GetMiddleName(int id)
            => _svc.GetMiddleNameForPerson(id)
                .Match(some: WriteMiddleNameLen, none: WriteMonadMessage);

        private static void WriteMiddleNameLen(string? middleName)
            => Console.WriteLine("MiddleName Len: " + (middleName?.Length ?? 0));

        private static void WriteMonadMessage(Maybe<string>? monad)
            => Console.WriteLine(monad?.Message ?? "No Additional Details");
    }
}
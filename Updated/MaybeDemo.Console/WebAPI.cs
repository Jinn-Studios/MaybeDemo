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
        public string? GetMiddleName(int id)
        {
            var middleName = _svc.GetMiddleNameForPerson(id);
            ValidateMiddleName(middleName);
            return middleName.Value;
        }

        private static void ValidateMiddleName(Maybe<string> middleName)
        {
            middleName.Match(
                x => Console.WriteLine("MiddleName Len: " + x!.Length),
                x => Console.WriteLine(x?.Message ?? "No Error Message")
            );

            Console.WriteLine("MiddleName: " + (middleName.Value ?? "`null`"));
        }
    }
}
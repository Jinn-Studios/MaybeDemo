namespace MaybeDemo
{
    public class PersonSDK
    {
        // Imagining this is an HttpClient that will eventually hit an API Endpoint.
        private readonly API.WebAPIController _httpSvc;

        public PersonSDK(API.WebAPIController httpSvc)
        {
            _httpSvc = httpSvc;
        }

#pragma warning disable IDE0060 // Just a demo
        public string? Get(string route, int id) => _httpSvc.GetMiddleName(id);
    }
}
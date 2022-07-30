public class PersonSDK
{
    private readonly WebAPIController _httpSvc;

    public PersonSDK(WebAPIController httpSvc)
    {
        _httpSvc = httpSvc;
    }

    public string Get(string route, int id) => _httpSvc.GetMiddleName(id);
}
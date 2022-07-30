using System.Collections.Generic;

public class Services
{
    public static List<PersonEntity> GetPeople()
    {
        var ppl = new List<PersonEntity>();
        ppl.Add("John", "F", "Kennedy");
        ppl.Add("Steve", null, "Fletch");
        ppl.Add("Awesome", null, "Possum");
        return ppl;
    }

    public static PersonSDK AddTransient<T>(List<PersonEntity> ppl)
    {
        var svc = new PersonService(new PersonRepo(ppl));
        var httpSvc = new WebAPIController(svc);
        return new PersonSDK(httpSvc);
    }
}
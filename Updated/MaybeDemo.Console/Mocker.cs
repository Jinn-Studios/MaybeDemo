namespace MaybeDemo;
using MaybeDemo.Data;
using MaybeDemo.Data.Entities;

// No need to look in this file.  It's test stuff behind the scenes.

public static class Mocker
{
    // Mocking out a collection of people to test with.
    public static List<PersonEntity> GetPeople()
    {
        return new List<PersonEntity>
            {
                { "John", "f", "Kennedy" },
                { "Super", "duper", "Pewperskewper" },
                { "Steve", null, "Fletch" },
                { "Awesome", null, "Possum", "Awesome mister Possum" }
            };
    }

    // Just a simple method to more easily add items to a list for this test.
    // Interestingly, this is used in the GetPeople above, but this shows 0 references.
    public static void Add(this List<PersonEntity> lst, string f, string? m, string l, string? fullName = null)
    {
        lst.Add(new PersonEntity
        {
            Id = lst.Count + 1,
            FirstName = f,
            MiddleName = m,
            LastName = l,
            FullNameRaw = fullName ?? ($"{f} {m} {l}")
        });
    }

    // Mock of Dependency Injection... don't copy this.
    public static PersonSDK AddTransient<T>(List<PersonEntity> ppl)
    {
        var svc = new PersonService(new PersonRepo(ppl));
        var httpSvc = new API.WebAPIController(svc);
        return new PersonSDK(httpSvc);
    }
}
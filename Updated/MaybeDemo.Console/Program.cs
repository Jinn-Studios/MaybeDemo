using MaybeDemo;

var ppl = Mocker.GetPeople();
var sdk = Mocker.AddTransient<PersonSDK>(ppl);

try
{
    foreach (var person in ppl)
    {
        Console.WriteLine("Check MiddleName For: " + person.FirstName);
        sdk.Get($"/api/Person/{person.Id}/MiddleName", person.Id);
        Console.WriteLine();
    }

    Console.WriteLine("Check MiddleName For: Unknown");
    sdk.Get("/api/Person/999/MiddleName", 999); // Meant to be an ID that doesn't exist in the DB
    Console.WriteLine();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Exception!!! WTHecken?");
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
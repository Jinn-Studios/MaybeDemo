using MaybeDemo;

var ppl = Mocker.GetPeople();
var sdk = Mocker.AddTransient<PersonSDK>(ppl);

try
{
    foreach (var person in ppl)
    {
        Console.WriteLine("Check MiddleName For: " + person.SomeStringVal);
        var mid = sdk.Get($"/api/Person/{person.Id}/MiddleName", person.Id);
        Console.WriteLine("MiddleName: " + (mid.Value ?? "`null`"));
        Console.WriteLine();
    }

    Console.WriteLine("Check MiddleName For: Unknown");
    var middleName = sdk.Get($"/api/Person/999/MiddleName", 999); // ID that doesn't exist in the DB
    Console.WriteLine("MiddleName: " + (middleName.Value ?? "`null`"));
    Console.WriteLine();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Exception!!! WTHecken?");
    Console.WriteLine(ex.Message);
    Console.ResetColor();
}
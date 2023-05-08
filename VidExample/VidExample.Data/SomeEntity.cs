namespace VidExample.Data.Entities
{
    public record SomeEntity
    {
        public int Id { get; set; }
        public int? NumOrSomething { get; set; }
        public string SomeStringVal { get; set; }
        public DateTime? SomeDateTime { get; set; }
        public string OtherStringVal { get; set; }
    }
}
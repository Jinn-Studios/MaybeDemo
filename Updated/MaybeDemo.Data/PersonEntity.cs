namespace MaybeDemo.Data.Entities
{
    public record PersonEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullNameRaw { get; set; }
    }
}
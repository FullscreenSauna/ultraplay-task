namespace UltraPlayApi.Interfaces
{
    public interface IOdd
    {
        int Id { get; set; }
        string Name { get; set; }
        int ExternalId { get; set; }
        string Value { get; set; }
        string? SpecialBetValue { get; set; }
    }
}
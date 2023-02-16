namespace UltraPlayApi.DatabaseViews
{
    public class AllMatches
    {
        public string MatchName { get; set; }

        public DateTime StartDate { get; set; }

        public string MarketName { get; set; }

        public string OddName { get; set; }

        public string? Value { get; set; }

        public string? SpecialBetValue { get; set; }

        public int ExternalId { get; set; }
    }
}

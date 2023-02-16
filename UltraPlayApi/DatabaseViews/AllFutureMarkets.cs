namespace UltraPlayApi.DatabaseViews
{
    public class AllFutureMarkets
    {
        public string MatchName { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public string MarketName { get; set; }

        public string OddName { get; set; }

        public string Odds { get; set; }
    }
}

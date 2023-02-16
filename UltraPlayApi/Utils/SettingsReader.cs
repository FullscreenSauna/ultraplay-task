namespace UltraPlayApi.Utils
{
    public static class SettingsReader
    {
        public static int GetDataFromFeedDelay()
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", false, true)
             .Build();

            return int.Parse(configuration["GetDataFromFeedDelay"]);
        }

        public static string XmlFeedUrl()
        {
            var configuration = new ConfigurationBuilder()
             .AddJsonFile("appsettings.json", false, true)
             .Build();

            return configuration["XmlFeedUrl"];
        }
    }
}

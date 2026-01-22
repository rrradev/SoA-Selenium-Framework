using Microsoft.Extensions.Configuration;
using SeleniumFramework.Models;

namespace SeleniumFramework.Utilities
{
    public class ConfigurationManager
    {
        private static readonly Lazy<ConfigurationManager> lazy =
            new(() => new ConfigurationManager());

        public static ConfigurationManager Instance { get; } = lazy.Value;

        public SettingsModel SettingsModel { get; private set; }

        private ConfigurationManager()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            SettingsModel = config.GetSection("Settings").Get<SettingsModel>()!;
        }
    }
}

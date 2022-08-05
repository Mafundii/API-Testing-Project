using System.Configuration;

namespace NameDaysAPIFramework;

public class ConfigReader
{
    public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
}

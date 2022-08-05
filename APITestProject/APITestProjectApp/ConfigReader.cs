using System.Configuration;

namespace APITestProjectApp;

public class ConfigReader
{
    public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
}

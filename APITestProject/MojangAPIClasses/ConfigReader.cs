using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDaysAPIFramework;

public class ConfigReader
{
    public static readonly string? BaseURL = ConfigurationManager.AppSettings["base_url"];
}

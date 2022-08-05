using MojangAPIClasses.DataHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameDaysAPIFramework.DataHandling;

public class NamedayResponse : IResponse
{
    public int day { get; set; }
    public int month { get; set; }
    public Nameday nameday { get; set; }
}

public class Nameday
{
    public string fi { get; set; }
    public string bg { get; set; }
    public string us { get; set; }
    public string hr { get; set; }
    public string es { get; set; }
    public string dk { get; set; }
    public string it { get; set; }
    public string lt { get; set; }
    public string gr { get; set; }
    public string fr { get; set; }
    public string hu { get; set; }
    public string at { get; set; }
    public string lv { get; set; }
    public string de { get; set; }
    public string ru { get; set; }
    public string pl { get; set; }
    public string sk { get; set; }
    public string se { get; set; }
    public string cz { get; set; }
    public string ee { get; set; }
}

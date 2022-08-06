using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayYesterdayTests.PostYesterday;

[Category("PostYesterday")]
public class WhenNameDayForYesterdayServiceIsCalled_WithPostMethodAndValidParameters
{
    NamedayForYesterdayService _nameDayForYesterdayService;
    DateTime _apiDefaultTime;
    [OneTimeSetUp]
    public void Setup()
    {
        _apiDefaultTime = DateTime.UtcNow.AddHours(2);
        _nameDayForYesterdayService = new NamedayForYesterdayService();
    }

    [Test]
    public async Task GivenNoParameters_Status200()
    {
        await _nameDayForYesterdayService.MakeRequest(Method.Post);
        Assert.That(_nameDayForYesterdayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenNoParameters_GivesAllCountryData()
    {
        await _nameDayForYesterdayService.MakeRequest(Method.Post);
        Assert.That(_nameDayForYesterdayService.JsonResponse["nameday"].Count, Is.EqualTo(20));
    }

    [Test]
    public async Task GivenNoParameters_DateIsYesterday()
    {
        await _nameDayForYesterdayService.MakeRequest(Method.Post);
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.day, Is.EqualTo(_apiDefaultTime.Day - 1));
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.month, Is.EqualTo(_apiDefaultTime.Month));
    }

    [Test]
    public async Task GivenCountry_Status200()
    {
        var param = new Dictionary<string, string>
{
    {"country", "pl" }
};

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenCountry_GivesCountryData()
    {
        var param = new Dictionary<string, string>
{
    {"country", "es" }
};

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.JsonResponse["nameday"].Count, Is.EqualTo(1));
    }

    [Test]
    public async Task GivenCountry_DateIsYesterday()
    {
        var param = new Dictionary<string, string>
{
    {"country", "us" }
};

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.day, Is.EqualTo(_apiDefaultTime.Day - 1));
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.month, Is.EqualTo(_apiDefaultTime.Month));
    }

    [Test]
    public async Task GivenTimezone_Status200()
    {
        var param = new Dictionary<string, string>
{
    {"timezone", "Europe/London" }
};

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenTimezone_GivesAllCountryData()
    {
        var param = new Dictionary<string, string>
{
    {"timezone", "Europe/Lisbon" }
};

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.JsonResponse["nameday"].Count, Is.EqualTo(20));
    }

    [Test]
    public async Task GivenTimezone_DateIsYesterday()
    {
        var param = new Dictionary<string, string>
{
    {"timezone", "Australia/Brisbane" }
};

        var date = DateTime.Now.AddHours(9);

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.day, Is.EqualTo(date.Day - 1));
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.month, Is.EqualTo(date.Month));
    }

    [Test]
    public async Task GivenCountryAndTimezone_DateIsYesterdayAndCountryDataIsListed()
    {
        var param = new Dictionary<string, string>
{
    {"country", "es" },
    {"timezone", "Australia/Brisbane" }
};

        var date = DateTime.Now.AddHours(9);

        await _nameDayForYesterdayService.MakeRequest(param, Method.Post);
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.day, Is.EqualTo(date.Day - 1));
        Assert.That(_nameDayForYesterdayService.NamedayTodayDTO.Response.month, Is.EqualTo(date.Month));
        Assert.That(_nameDayForYesterdayService.JsonResponse["nameday"].Count, Is.EqualTo(1));
    }
}

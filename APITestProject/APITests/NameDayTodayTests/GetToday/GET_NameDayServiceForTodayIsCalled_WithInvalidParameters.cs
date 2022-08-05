using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayTodayTests.GetToday;

public class WhenNameDayServiceIsCalled_WithInvalidParameters
{
    NamedayForTodayService _nameDayForTodayService;
    [OneTimeSetUp]
    public void Setup()
    {
        _nameDayForTodayService = new NamedayForTodayService();
    }

    [Test]
    public async Task SpecifiedCountryIsInvalid_Status422()
    {
        var param = new Dictionary<string, string>
        {
            { "country", "aa" }
        };
        await _nameDayForTodayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForTodayService.GetStatusCode(), Is.EqualTo(422));
    }
    
    [Test]
    public async Task SpecifiedCountryIsInvalid_GivesRelevantErrorMessage()
    {
        var param = new Dictionary<string, string>
        {
            { "country", "aa" }
        };
        await _nameDayForTodayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForTodayService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
    }

    [Test]
    public async Task SpecifiedTimezoneIsInvalid_Status422()
    {
        var param = new Dictionary<string, string>
        {
            { "timezone", "aa" }
        };
        await _nameDayForTodayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForTodayService.GetStatusCode(), Is.EqualTo(422));
    }

    [Test]
    public async Task SpecifiedTimezoneIsInvalid_GivesRelevantErrorMessage()
    {
        var param = new Dictionary<string, string>
        {
            { "timezone", "aa" }
        };
        await _nameDayForTodayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForTodayService.JsonResponse["error"]["timezone"][0].ToString(), Is.EqualTo("The selected timezone is invalid."));
    }
}

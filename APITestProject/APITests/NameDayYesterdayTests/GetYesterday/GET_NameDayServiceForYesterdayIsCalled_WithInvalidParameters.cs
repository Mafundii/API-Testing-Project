using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayYesterdayTests.GetYesterday;

[Category("GetYesterday")]
public class WhenNameDayForYesterdayServiceIsCalled_WithGetMethodAndInvalidParameters
{
    NamedayForYesterdayService _nameDayForYesterdayService;
    [OneTimeSetUp]
    public void Setup()
    {
        _nameDayForYesterdayService = new NamedayForYesterdayService();
    }

    [Test]
    public async Task SpecifiedCountryIsInvalid_Status422()
    {
        var param = new Dictionary<string, string>
        {
        { "country", "aa" }
        };
        await _nameDayForYesterdayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForYesterdayService.GetStatusCode(), Is.EqualTo(422));
    }

    [Test]
    public async Task SpecifiedCountryIsInvalid_GivesRelevantErrorMessage()
    {
        var param = new Dictionary<string, string>
    {
        { "country", "aa" }
    };
        await _nameDayForYesterdayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForYesterdayService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
    }

    [Test]
    public async Task SpecifiedTimezoneIsInvalid_Status422()
    {
        var param = new Dictionary<string, string>
    {
        { "timezone", "aa" }
    };
        await _nameDayForYesterdayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForYesterdayService.GetStatusCode(), Is.EqualTo(422));
    }

    [Test]
    public async Task SpecifiedTimezoneIsInvalid_GivesRelevantErrorMessage()
    {
        var param = new Dictionary<string, string>
    {
        { "timezone", "aa" }
    };
        await _nameDayForYesterdayService.MakeRequest(param, Method.Get);

        Assert.That(_nameDayForYesterdayService.JsonResponse["error"]["timezone"][0].ToString(), Is.EqualTo("The selected timezone is invalid."));
    }
}

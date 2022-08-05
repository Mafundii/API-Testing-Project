﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayTodayTests.GetToday;

public class GET_NameDayServiceForTodayIsCalled_WithValidParameters
{
    NamedayForTodayService _nameDayForTodayService;
    [OneTimeSetUp]
    public void Setup()
    {
        _nameDayForTodayService = new NamedayForTodayService();
    }

    [Test]
    public async Task GivenNoParameters_Status200()
    {
        await _nameDayForTodayService.MakeRequest(Method.Get);
        Assert.That(_nameDayForTodayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenNoParameters_GivesAllCountryData()
    {
        await _nameDayForTodayService.MakeRequest(Method.Get);
        Assert.That(_nameDayForTodayService.JsonResponse["nameday"].Count, Is.EqualTo(20));
    }

    [Test]
    public async Task GivenNoParameters_DateIsToday()
    {
        await _nameDayForTodayService.MakeRequest(Method.Get);
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.day, Is.EqualTo(DateTime.Now.Day));
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.month, Is.EqualTo(DateTime.Now.Month));
    }

    [Test]
    public async Task GivenCountry_Status200()
    {
        var param = new Dictionary<string, string>
        {
            {"country", "pl" }
        };

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenCountry_GivesCountryData()
    {
        var param = new Dictionary<string, string>
        {
            {"country", "es" }
        };

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.JsonResponse["nameday"].Count, Is.EqualTo(1));
    }

    [Test]
    public async Task GivenCountry_DateIsToday()
    {
        var param = new Dictionary<string, string>
        {
            {"country", "us" }
        };

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.day, Is.EqualTo(DateTime.Now.Day));
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.month, Is.EqualTo(DateTime.Now.Month));
    }

    [Test]
    public async Task GivenTimezone_Status200()
    {
        var param = new Dictionary<string, string>
        {
            {"timezone", "Europe/London" }
        };

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.GetStatusCode(), Is.EqualTo(200));
    }

    [Test]
    public async Task GivenTimezone_GivesAllCountryData()
    {
        var param = new Dictionary<string, string>
        {
            {"timezone", "Europe/Lisbon" }
        };

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.JsonResponse["nameday"].Count, Is.EqualTo(20));
    }

    [Test]
    public async Task GivenTimezone_DateIsToday()
    {
        var param = new Dictionary<string, string>
        {
            {"timezone", "Australia/Brisbane" }
        };

        var date = DateTime.Now.AddHours(9);

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.day, Is.EqualTo(date.Day));
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.month, Is.EqualTo(date.Month));
    }

    [Test]
    public async Task GivenCountryAndTimezone_DateIsTodayAndCountryDataIsListed()
    {
        var param = new Dictionary<string, string>
        {
            {"country", "es" },
            {"timezone", "Australia/Brisbane" }
        };

        var date = DateTime.Now.AddHours(9);

        await _nameDayForTodayService.MakeRequest(param, Method.Get);
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.day, Is.EqualTo(date.Day));
        Assert.That(_nameDayForTodayService.NamedayTodayDTO.Response.month, Is.EqualTo(date.Month));
        Assert.That(_nameDayForTodayService.JsonResponse["nameday"].Count, Is.EqualTo(1));
    }
}

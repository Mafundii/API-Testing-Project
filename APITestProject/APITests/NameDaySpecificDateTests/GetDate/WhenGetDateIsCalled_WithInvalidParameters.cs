﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.GetDate
{
    [Category("GetDate")]
    public class WhenGetDateIsCalled_WithInvalidParameters
    {
        NamedayForDateService _namedayForDateService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _namedayForDateService = new NamedayForDateService();
        }

        [Test]
        public async Task GivenDayLessThanOne_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "0" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenDayLessThanOne_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "0" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["day"][0].ToString(), Is.EqualTo("The day must be at least 1."));
        }
        [Test]
        public async Task GivenDayGreaterThan31_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "32" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenDayGreaterThan31_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "32" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["day"][0].ToString(), Is.EqualTo("The day must not be greater than 31."));
        }
        [Test]
        public async Task GivenInvalidDate_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "2" }, { "month", "31" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenInvalidDate_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "31" }, { "month", "2" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("Date is invalid"));
        }
        [Test]
        public async Task GivenNonIntegerDay_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "x" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNonIntegerDay_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "x" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["day"][0].ToString(), Is.EqualTo("The day must be a number."));
        }
        [Test]
        public async Task GivenEmptyDay_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenEmptyDay_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "" }, { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["day"][0].ToString(), Is.EqualTo("The day field is required."));
        }
        [Test]
        public async Task GivenDayMissing_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenDayMissing_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "month", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["day"][0].ToString(), Is.EqualTo("The day field is required."));
        }

        [Test]
        public async Task GivenMonthLessThanOne_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "0" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenMonthLessThanOne_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "0" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("The month must be at least 1."));
        }
        [Test]
        public async Task GivenMonthGreaterThan12_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "13" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenMonthGreaterThan12_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "13" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("The month must not be greater than 12."));
        }
        [Test]
        public async Task GivenNonIntegerMonth_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "x" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNonIntegerMonth_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "x" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("The month must be a number."));
        }
        [Test]
        public async Task GivenEmptyMonth_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenEmptyMonth_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("The month field is required."));
        }
        [Test]
        public async Task GivenMonthMissing_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenMonthMissing_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["month"][0].ToString(), Is.EqualTo("The month field is required."));
        }

        [Test]
        public async Task GivenInvalidCountry_GetDate_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "1" }, { "country", "x" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(422));
        }

        [Test]
        public async Task GivenInvalidCountry_GetDate_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "day", "1" }, { "month", "1" }, { "country", "x" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
        }
    }
}

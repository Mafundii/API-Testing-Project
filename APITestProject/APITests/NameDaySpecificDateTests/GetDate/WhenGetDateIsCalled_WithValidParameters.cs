using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.GetDate
{
    public class WhenGetDateIsCalled_WithValidParameters
    {
        NamedayForDateService _namedayForDateService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _namedayForDateService = new NamedayForDateService();
        }

        [Category("Valid Day and Month")]
        [Test]
        public async Task GivenValidDayAndMonth_GetDate_ReturnsStatusCode200()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(200));
        }
        [Test]
        public async Task GivenValidDayAndMonth_GetDate_ReturnsExpectedDay()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["day"].ToString(), Is.EqualTo("29"));
        }
        [Test]
        public async Task GivenValidDayAndMonth_GetDate_ReturnsExpectedMonth()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["month"].ToString(), Is.EqualTo("2"));
        }
        [Test]
        public async Task GivenValidDayAndMonth_GetDate_ReturnsNamedays()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["nameday"], Does.ContainKey("us"));
        }



        [Category("Valid Day, Month, and Country")]
        public async Task GivenValidDayMonthAndCountry_GetDate_ReturnsStatusCode200()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.GetStatusCode(), Is.EqualTo(200));
        }
        [Test]
        public async Task GivenValidDayMonthAndCountry_GetDate_ReturnsExpectedDay()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["day"].ToString(), Is.EqualTo("29"));
        }
        [Test]
        public async Task GivenValidDayMonthAndCountry_GetDate_ReturnsExpectedMonth()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["month"].ToString(), Is.EqualTo("2"));
        }
        [Test]
        public async Task GivenValidDayMonthAndCountry_GetDate_ReturnsExpectedNamedays()
        {
            var param = new Dictionary<string, string> { { "day", "29" }, { "month", "2" }, { "country", "us" } };
            await _namedayForDateService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForDateService.JsonResponse["nameday"], Does.ContainKey("us"));
        }
    }
}

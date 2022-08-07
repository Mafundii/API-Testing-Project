using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayTomorrowTests.GetTomorrow
{
    public class GET_NameDayServiceForTomorrowIsCalled_WithValidParameters
    {
        NamedayForTomorrowService _namedayForTomorrowService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _namedayForTomorrowService = new NamedayForTomorrowService();
        }

        [Test]
        public async Task GivenNoParameters_PostRequestForNamedayTomorrow_ReturnsAllNamedaysForTomorrow()
        {
            await _namedayForTomorrowService.MakeRequest(Method.Get);

            Assert.That(_namedayForTomorrowService.JsonResponse["nameday"].Count, Is.EqualTo(20));
        }

        [Test]
        public async Task GivenNoParameters_PostRequestForNamedayTomorrow_ReturnsStatus200()
        {
            await _namedayForTomorrowService.MakeRequest(Method.Get);

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(200));
        }

        [Test]
        public async Task GivenCountryParameters_PostRequestForNamedayTomorrow_ReturnsCountryNamedaysForTomorrow()
        {
            var param = new Dictionary<string, string>
            {
                {"country", "pl" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Get);

            Assert.That(_namedayForTomorrowService.JsonResponse["nameday"].Count, Is.EqualTo(1));
        }

        [Test]
        public async Task GivenCountryParameters_PostRequestForNamedayTomorrow_ReturnsStatus200()
        {
            var param = new Dictionary<string, string>
            {
                {"country", "pl" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Get);

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(200));
        }

        [Test]
        public async Task GivenTimezoneParameters_PostRequestForNamedayTomorrow_ReturnsTimezoneNamedaysForTomorrow()
        {
            var param = new Dictionary<string, string>
            {
                { "timezone", "Europe/Lisbon" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Get);

            Assert.That(_namedayForTomorrowService.JsonResponse["nameday"].Count, Is.EqualTo(20));
        }

        [Test]
        public async Task GivenTimezoneParameters_PostRequestForNamedayTomorrow_ReturnsStatus200()
        {
            var param = new Dictionary<string, string>
            {
                { "timezone", "Europe/Lisbon" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Get);

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(200));
        }
    }
}

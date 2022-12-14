using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayTomorrowTests.PostTomorrow
{
    [Category("PostTomorrow")]
    public class POST_NameDayServiceForTomorrowIsCalled_WithInvalidParameters
    {
        NamedayForTomorrowService _namedayForTomorrowService;

        [OneTimeSetUp]
        public async Task OneTimeSetupAsync()
        {
            _namedayForTomorrowService = new NamedayForTomorrowService();
        }

        [Test]
        public async Task GivenAnInvalidCountryInput_PostRequestForNamedayTomorrow_ReturnsError422()
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "country", "xx" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Post);

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(422));
        }

        [Test]
        public async Task GivenAnInvalidCountryInput_PostRequestForNamedayTomorrow_ReturnsRelevantMessage()
        {
            Dictionary<string, string> param = new Dictionary<string, string>
            {
                { "country", "xx" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Post);

            Assert.That(_namedayForTomorrowService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
        }

        [Test]
        public async Task GivenAnInvalidTimezoneInput_PostRequestForNamedayTomorrow_ReturnsError422()
        {
            Dictionary<string, string> param = new()
            {
                { "timezone", "xx" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Post);

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(422));
        }

        [Test]
        public async Task GivenAnInvalidTimezoneInput_PostRequestForNamedayTomorrow_ReturnsRelevantMessage()
        {
            Dictionary<string, string> param = new()
            {
                { "timezone", "xx" }
            };

            await _namedayForTomorrowService.MakeRequest(param, Method.Post);

            Assert.That(_namedayForTomorrowService.JsonResponse["error"]["timezone"][0].ToString(), Is.EqualTo("The selected timezone is invalid."));
        }



    }
}

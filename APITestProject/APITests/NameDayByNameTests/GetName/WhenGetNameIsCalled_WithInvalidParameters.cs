using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.GetName
{
    [Category("GetName")]
    public class WhenGetNameIsCalled_WithInvalidParameters
    {
        NamedayForNameService _namedayForNameService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _namedayForNameService = new NamedayForNameService();
        }

        [Test]
        public async Task GivenNameWithOneCharacter_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "x" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNameWithOneCharacter_GetName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "x" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["error"]["name"][0].ToString(), Is.EqualTo("The name must be at least 2 characters."));
        }
        [Test]
        public async Task GivenNameWithZeroCharacter_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNameWithZeroCharacter_GetName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["error"]["name"][0].ToString(), Is.EqualTo("The name field is required."));
        }
        [Test]
        public async Task GivenNameMissing_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }

        [Test]
        public async Task GivenInvalidCountry_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "nooooo" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenInvalidCountry_GetName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "nooooo" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
        }
        [Test]
        public async Task GivenEmptyCountry_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenEmptyCountry_GetName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The country field is required."));
        }
        [Test]
        public async Task GivenCountryMissing_GetName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenCountryMissing_GetName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The country field is required."));
        }

    }
}

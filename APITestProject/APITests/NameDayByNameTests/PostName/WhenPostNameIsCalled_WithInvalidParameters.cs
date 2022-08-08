using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.PostName
{
    public class WhenPostNameIsCalled_WithInvalidParameters
    {
        NamedayForNameService _namedayForNameService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _namedayForNameService = new NamedayForNameService();
        }

        [Category("Invalid Name")]
        [Test]
        public async Task GivenNameWithOneCharacter_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "x" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNameWithOneCharacter_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "x" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["name"][0].ToString(), Is.EqualTo("The name must be at least 2 characters."));
        }
        [Test]
        public async Task GivenNameWithZeroCharacter_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNameWithZeroCharacter_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["name"][0].ToString(), Is.EqualTo("The name field is required."));
        }
        [Test]
        public async Task GivenNameMissing_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenNameMissing_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["name"][0].ToString(), Is.EqualTo("The name field is required."));
        }


        [Category("Invalid Country")]
        [Test]
        public async Task GivenInvalidCountry_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "nooooo" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenInvalidCountry_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "nooooo" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The selected country is invalid."));
        }
        [Test]
        public async Task GivenEmptyCountry_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenEmptyCountry_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" }, { "country", "" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The country field is required."));
        }
        [Test]
        public async Task GivenCountryMissing_PostName_ReturnsError422()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(422));
        }
        [Test]
        public async Task GivenCountryMissing_PostName_ReturnsRelevantErrorMessage()
        {
            var param = new Dictionary<string, string> { { "name", "Dan" } };
            await _namedayForNameService.MakeRequest(param, Method.Post);
            Assert.That(_namedayForNameService.JsonResponse["error"]["country"][0].ToString(), Is.EqualTo("The country field is required."));
        }
    }
}

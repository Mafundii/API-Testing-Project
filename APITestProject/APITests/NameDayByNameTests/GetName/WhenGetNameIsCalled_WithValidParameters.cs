using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.GetName
{
    [Category("GetName")]
    public class WhenGetNameIsCalled_WithValidParameters
    {
        NamedayForNameService _namedayForNameService;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _namedayForNameService = new NamedayForNameService();
        }

        [Test]
        public async Task GivenValidNameAndCountry_GetName_ReturnsStatusCode200()
        {
            var param = new Dictionary<string, string> { { "name", "Kai" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.GetStatusCode(), Is.EqualTo(200));
        }

        [Test]
        public async Task GivenValidNameAndCountry_GetName_ReturnsGivenName()
        {
            var param = new Dictionary<string, string> { { "name", "Kai" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That(_namedayForNameService.JsonResponse["0"][0]["name"].ToString(), Does.Contain("Kai"));
        }
        [Test]
        public async Task GivenValidNameAndCountry_GetName_ReturnsMonth()
        {
            var param = new Dictionary<string, string> { { "name", "Kai" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That((int)_namedayForNameService.JsonResponse["0"][0]["month"], Is.InRange(1, 12));
        }
        [Test]
        public async Task GivenValidNameAndCountry_GetName_ReturnsDay()
        {
            var param = new Dictionary<string, string> { { "name", "Kai" }, { "country", "us" } };
            await _namedayForNameService.MakeRequest(param, Method.Get);
            Assert.That((int)_namedayForNameService.JsonResponse["0"][0]["day"], Is.InRange(1, 31));
        }
    }
}

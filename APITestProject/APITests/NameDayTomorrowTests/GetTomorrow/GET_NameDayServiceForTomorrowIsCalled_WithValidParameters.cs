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

            Assert.That(_namedayForTomorrowService.GetStatusCode(), Is.EqualTo(200));
            Assert.That(_namedayForTomorrowService.JsonResponse["nameday"].Count, Is.EqualTo(20));
            
        }

        //[Test]
        //public void GivenASpecifiedCountry_PostRequestForNamedayTomorrow_ReturnsOnlyNamedaysForThatCountry()
        //{

        //}

        //[Test]
        //public void GivenASpecifiedTimezone_PostRequestForNamedayTomorrow_ReturnsOnlyNamedaysForThatTimezone()
        //{

        //}
    }
}

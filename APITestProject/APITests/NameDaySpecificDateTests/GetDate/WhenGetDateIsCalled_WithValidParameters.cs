using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.GetDate
{
    public class WhenGetDateIsCalled_WithValidParameters
    {
        GetDate = _getDate;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _getDate = new GetDate();
            await _getDate.MakesRequestAsync();
        }
        public void GivenValidDayAndMonth_XXX_ReturnsExpectedResult()
        {
            throw new NotImplementedException();
        }
        public void GivenValidDayAndMonthAndValidCountry_XXX_ReturnsExpectedResult()
        {
            throw new NotImplementedException();
        }
    }
}

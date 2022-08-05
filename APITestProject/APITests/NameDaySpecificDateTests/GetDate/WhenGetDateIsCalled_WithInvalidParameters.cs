using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.GetDate
{
    public class WhenGetDateIsCalled_WithInvalidParameters
    {
        GetDate = _getDate;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _getDate = new GetDate();
            await _getDate.MakesRequestAsync();
        }
        public void GivenInvalidName_XXX_ReturnsError422()
        {
            throw new NotImplementedException();
        }
        public void GivenInvalidCountry_XXX_ReturnsError422()
        {
            throw new NotImplementedException();
        }
    }
}

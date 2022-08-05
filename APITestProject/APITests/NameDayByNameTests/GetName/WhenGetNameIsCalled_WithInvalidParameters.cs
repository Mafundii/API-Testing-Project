using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.GetName
{
    public class WhenGetNameIsCalled_WithInvalidParameters
    {
        GetName = _getName;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _getName = new GetName();
            await _getName.MakesRequestAsync();
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

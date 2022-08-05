using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.PostDate
{
    public class WhenPostDateIsCalled_WithValidParameters
    {
        PostDate = _postDate;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _postDate = new PostDate();
            await _postDate.MakesRequestAsync();
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

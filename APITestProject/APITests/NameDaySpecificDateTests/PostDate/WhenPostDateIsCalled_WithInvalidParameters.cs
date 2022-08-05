using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDaySpecificDateTests.PostDate
{
    public class WhenPostDateIsCalled_WithInvalidParameters
    {
        PostDate = _postDate;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _postDate = new PostDate();
            await _postDate.MakesRequestAsync();
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

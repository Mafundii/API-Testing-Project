using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.PostName
{
    public class WhenPostNameIsCalled_WithInvalidParameters
    {
        PostName = _postName;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _postName = new PostName();
            await _postName.MakesRequestAsync();
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

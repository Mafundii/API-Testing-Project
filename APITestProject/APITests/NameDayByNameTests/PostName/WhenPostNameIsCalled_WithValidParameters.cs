using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.PostName
{
    public class WhenPostNameIsCalled_WithValidParameters
    {
        PostName = _postName;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _postName = new PostName();
            await _postName.MakesRequestAsync();
        }
        public void GivenValidName_XXX_ReturnsExpectedResult()
        {
            throw new NotImplementedException();
        }
        public void GivenValidNameAndValidCountry_XXX_ReturnsExpectedResult()
        {
            throw new NotImplementedException();
        }
    }
}

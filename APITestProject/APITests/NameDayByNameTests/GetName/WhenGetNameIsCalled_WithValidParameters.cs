﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.NameDayByNameTests.GetName
{
    public class WhenGetNameIsCalled_WithValidParameters
    {
        GetName = _getName;

        [OneTimeSetUp]
        public async Task OneTimeSetUpAsync()
        {
            _getName = new GetName();
            await _getName.MakesRequestAsync();
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

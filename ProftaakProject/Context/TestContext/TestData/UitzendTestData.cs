using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext.TestData
{
    class UitzendTestData
    {
        public static List<Uitzendbureau> ResetData()
        {
            return new List<Uitzendbureau>()
            {
                new Uitzendbureau(1, "Easyflex", 1),
                new Uitzendbureau(2, "Bolt", 2),
                new Uitzendbureau(3, "Randstad", 3)

            };
        }
    }
}

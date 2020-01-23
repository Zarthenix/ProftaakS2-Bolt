using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext.TestData
{
    class TagTestData
    {
        public List<Tag> ResetData()
        {
            return new List<Tag>()
            {
                new Tag(1, "Wetswijziging"),
                new Tag(2, "Financieel"),
                new Tag(3, "Intern")
            };
        }
    }
}

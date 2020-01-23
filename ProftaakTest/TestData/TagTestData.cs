using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakTest.TestData
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

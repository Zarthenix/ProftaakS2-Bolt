﻿using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakTest.TestData
{
    class ReactieTestData
    {
        public List<Reactie> ResetData()
        {
            return new List<Reactie>()
            {
                new Reactie(1, "Test reactie #1", DateTime.Now, 1)
                {
                    Goedgekeurd = false
                },
                new Reactie(2, "Test reactie #2", Convert.ToDateTime("2019-02-02 22:20"), 2)
                {
                    Goedgekeurd = true,
                    GoedgekeurdDoor = 1
                },
                new Reactie(3, "Test reactie #3", Convert.ToDateTime("2020-01-01 00:05"), 3)
                {
                    Goedgekeurd = false
                }
            };
        }
    }
}

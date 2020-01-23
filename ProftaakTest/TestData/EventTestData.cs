using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakTest.TestData
{
    class EventTestData
    {
        public static List<Evenement> ResetData()
        {
            return new List<Evenement>()
            {
                new Evenement(1)
                {
                    Naam = "Test evenement 1",
                    Datum = Convert.ToDateTime("2020-04-03 10:00"),
                    Host = 1,
                    Locatie = "EasyFlex",
                    MaxDeelnemers = 100
                },
                new Evenement(2)
                {
                    Naam = "Test evenement 2",
                    Datum = Convert.ToDateTime("2020-05-12 15:00"),
                    Host = 1,
                    Locatie = "Fontys",
                    MaxDeelnemers = 10
                },
                new Evenement(3)
                {
                    Naam = "Test evenement 3",
                    Datum = Convert.ToDateTime("2020-04-11 23:00"),
                    Host = 2,
                    Locatie = "Breda",
                    MaxDeelnemers = 3
                }
            };
        }
    }
}

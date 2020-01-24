using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext.TestData
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
                    Host = new Account(1, "Test"),
                    Locatie = "EasyFlex",
                    MaxDeelnemers = 100,
                    Uitzendbureau = new Uitzendbureau(1)
                },
                new Evenement(2)
                {
                    Naam = "Test evenement 2",
                    Datum = Convert.ToDateTime("2020-05-12 15:00"),
                    Host = new Account(2, "Test2"),
                    Locatie = "Fontys",
                    MaxDeelnemers = 10,
                    Uitzendbureau = new Uitzendbureau(2)
                },
                new Evenement(3)
                {
                    Naam = "Test evenement 3",
                    Datum = Convert.ToDateTime("2020-04-11 23:00"),
                    Host = new Account(3, "Test 3"),
                    Locatie = "Breda",
                    MaxDeelnemers = 3,
                    Uitzendbureau = new Uitzendbureau(3)
                }
            };
        }
    }
}

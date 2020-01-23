using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakTest.TestData
{
    public class AccountTestData
    {
        public static List<Account> ResetData()
        {
            return new List<Account>()
            {
                new Account(1,  "TestAcc1", "test1@test.nl")
                {
                    GeabonneerdeTags = new List<Tag>()
                    {
                        new Tag(1, "Wetswijziging"),
                        new Tag(2, "Financieel"),
                        new Tag(3, "Regelingen")
                    },
                    Geboortedatum = DateTime.Now,
                    Geslacht = Genders.Anders,
                    Naam = "Test-Jan Klaassen",
                    Rol = new Role(1, "Admin")
                },
                new Account(2, "TestAcc2", "test2@test.nl")
                {
                    GeabonneerdeTags = new List<Tag>()
                    {
                        new Tag(1, "Wetswijziging"),
                        new Tag(3, "Regelingen")
                    },
                    Geboortedatum = Convert.ToDateTime("1999-01-01 22:00"),
                    Geslacht = Gender.Man,
                    Naam = "Dokter Testerandus",
                    Rol = new Role(2, "Service-afdeling")
                },
                new Account(3, "TestAcc3", "test3@test.nl")
                {
                    GeabonneerdeTags = new List<Tag>()
                    {
                        new Tag(4, "Activiteiten"),
                        new Tag(5, "Intern")
                    }
                    Geboortedatum = Convert.ToDateTime("1982-04-05 09:22"),
                    Geslacht = Gender.Vrouw,
                    Naam = "Tess Ter Testeringen",
                    Rol = new Role(3, "Gebruiker")
                }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext.TestData
{
    class PostTestData
    {
        public List<Post> ResetData()
        {
            return new List<Post>()
            {
                new Post(1, "Test Post 1", "Dit is een testpost om te testen of de methodes goed werken.", 1,  
                    new Tag(1, "Wetswijziging"), 1, new Account(-1), new byte[1], false, 0)
                {
                    Auteur = new Account(1, "Test 1", "test@test.nl"),
                    AantalBekenen = 10,
                    Datum = DateTime.Now
                },
                new Post(2, "Test Post 2", "Dit is ook een testpost om dezelfde reden als bij de vorige post het geval was", 0, 
                    new Tag(2, "Financieel"), 2, new Account(-1),new byte[1], true, 1 )
                {
                    Auteur = new Account(2, "Test 2", "tast@tast.nl"),
                    AantalBekenen = 250,
                    Datum = Convert.ToDateTime("2018-02-02 22:22")
                },
                new Post(3, "Test Post 3", "En ten slotte nog eentje", 2, 
                    new Tag(3, "Intern"), 3, new Account(-1),new byte[1], false, 1 )
                {
                    Auteur = new Account(3, "Test 3", "tost@tost.nl"),
                    AantalBekenen = 19923,
                    Datum = Convert.ToDateTime("2020-01-01 00:01")
                }
            };
        }
    }
}

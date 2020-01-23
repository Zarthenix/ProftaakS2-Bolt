using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProftaakProject.Context.Interfaces;
using ProftaakProject.Models;

namespace ProftaakProject.Context.TestContext
{
    public class TestTagContext : ITagContext
    {
        public List<Tag> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tag GetTagByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetAllByUserID(int id)
        {
            throw new NotImplementedException();
        }

        public bool AbonnerenOpTag(int tagId, int accId)
        {
            throw new NotImplementedException();
        }

        public bool AbonnerenTagOpzeggen(int tagId, int accId)
        {
            throw new NotImplementedException();
        }

        public bool IsGeabonneerdOpTag(int tagId, int accId)
        {
            throw new NotImplementedException();
        }

        public List<Tag> GetAllGeabonneerdeTags(int accId)
        {
            throw new NotImplementedException();
        }
    }
}

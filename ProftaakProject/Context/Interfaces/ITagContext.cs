using ProftaakProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProftaakProject.Context.Interfaces
{
    public interface ITagContext
    {
        List<Tag> GetAll();
        Tag GetTagByID(int id);
        List<Tag> GetAllByUserID(int id);
    }
}

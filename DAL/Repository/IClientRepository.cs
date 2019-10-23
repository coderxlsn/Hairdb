using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    public interface IClientRepository
    {
        UtClient Create(string name, string phone);
        bool Remove(int id);
        List<UtClient> GetAll();
    }
}

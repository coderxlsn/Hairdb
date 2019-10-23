using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    public interface IUserRepository
    {
        UtUsers Login(string login, string password);
        UtUsers Create(CreateUserInputModel model);
        bool Remove(RemoveUserInputModel model);
        List<string> GetClient(string groupId);
        UtUsers CheckLogin(string username);
    }
}

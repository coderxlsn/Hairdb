using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
        /// <summary>
        /// Login function
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UtUsers Login(string login, string password) => _context.UtUsers.FirstOrDefault(x => x.Username == login && x.Userpws == password);
        public UtUsers Create(CreateUserInputModel model)
        {
            UtUsers row = new UtUsers()
            {
                Email = model.Email,
                Username = model.UserName,
                Userpws = model.UserPassword,
                UserGroupId = model.GroupId,
                ColorId = model.ColorId,
                CompanyName = model.CompanyName,
                FullName = model.FullName,
                Id = LastId() + 1

            };
            _context.Add(row);
            _context.SaveChanges();
            return row;

        }
        /// <summary>
        ///  Remove User
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        public bool Remove(RemoveUserInputModel inputModel)
        {
            UtUsers row = CheckUser(inputModel);
            if(row != null)
            {
                _context.Remove(row);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public UtUsers CheckLogin(string username) => _context.UtUsers.FirstOrDefault(x => x.Username == username);
        private UtUsers CheckUser(RemoveUserInputModel model) => _context.UtUsers.FirstOrDefault(x => x.Username == model.UserName && x.UserGroupId == model.GroupId);
        private int LastId() =>  _context.UtUsers.Count();
        public List<string> GetClient(string groupId)
        {
            return _context.UtUsers.Where(x => x.UserGroupId == groupId).Select(x => x.FullName).ToList();
        }
        
    }
}

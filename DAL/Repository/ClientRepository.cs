using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    public class ClientRepository:BaseRepository,IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context) { }
        /// <summary>
        /// Create Client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        public UtClient Create(string name,string phone)
        {
            var row = new UtClient() { 
            Name = name,
            Phone = phone};
            _context.UtClient.Add(row);
            _context.SaveChanges();
            return row;
        }
        public bool Remove(int id)
        {
            var row = _context.UtClient.FirstOrDefault(x => x.Id == id);
            if(row == null)
            {
                return false;
            }
            _context.UtClient.Remove(row);
            _context.SaveChanges();
            return true;
        }
        public List<UtClient> GetAll() => _context.UtClient.ToList();
    }
}

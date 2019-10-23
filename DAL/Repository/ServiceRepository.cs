using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    public class ServiceRepository : BaseRepository,IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context) { }
        public UtService Create(string name,string time)
        {
            var row = new UtService()
            {
                Name = name,
                TimeName = time
            };
            _context.UtService.Add(row);
            _context.SaveChanges();
            return row;
        }
        public bool Remove(int id)
        {
            var row = _context.UtService.FirstOrDefault(x => x.Id == id);
            if(row == null)
            {
                return false;
            }
            _context.Remove(row);
            _context.SaveChanges();
            return true;
        }
        public List<UtService> GetAll() => _context.UtService.ToList();
    }
}

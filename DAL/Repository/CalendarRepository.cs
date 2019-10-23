using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;

namespace Hairdb.DAL.Repository
{
    public class CalendarRepository : BaseRepository, ICalendarRepository
    {
        public CalendarRepository(ApplicationDbContext context) : base(context) { }
        public bool Create(CreateCalendarInputModel inputModel)
        {
            DateTime starDate = DateTime.ParseExact(inputModel.StartDateTime.ToString(), "ddMMyyyyhhmm", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(inputModel.EndDateTime.ToString(), "ddMMyyyyhhmm", CultureInfo.InvariantCulture);
            var user = FindUser(inputModel.UserName);
            UtCalander row = new UtCalander()
            {
                AddbyUserId = inputModel.AddbyUserId,
                ClientName = inputModel.ClientName,
                CreatedDtime = new DateTime(),
                EndDtime = endDate,
                EventDescription = inputModel.EventDescription,
                EventName = inputModel.EventName,
                StartDtime = starDate,
                UserId = user.Id,
                EventId = Guid.NewGuid().ToString()

            };
            _context.UtCalander.Add(row);
            return true;
            
        }
        public bool Remove(RemoveCalendarInputModel inputModel)
        {
            UtUsers user = FindUser(inputModel.UserName);
            var row = _context.UtCalander.FirstOrDefault(x => x.EventId == inputModel.EventId && x.UserId == user.Id);
            if(row != null)
            {
                _context.UtCalander.Remove(row);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        private UtUsers FindUser(string username) => _context.UtUsers.FirstOrDefault(x => x.Username == username);
        /// <summary>
        /// Поиск по ид юзера и дате
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="mode"></param>
        /// <param name="startDate"></param>
        /// <returns></returns>
        public List<UtCalander> FindCalendar(int userId, string mode, string startDate = null)
        {
            if(mode == "ALL")
            {
                return _context.UtCalander.Where(x => x.UserId == userId ).ToList();

            }
            if (startDate != null)
            {
                DateTime start = DateTime.ParseExact(startDate, "ddMMyyyyhhmm", CultureInfo.InvariantCulture);

                switch (mode)
                {
                    case "DAY":
                        return _context.UtCalander.Where(x => x.UserId == userId && x.StartDtime < start && x.EndDtime > start).ToList();
                    case "FROM":
                        return _context.UtCalander.Where(x => x.UserId == userId && x.StartDtime > start).ToList();
                }
            }
            return null;
        }
    }
}

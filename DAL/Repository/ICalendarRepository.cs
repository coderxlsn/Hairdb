using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.DAL.Repository
{
    public interface ICalendarRepository
    {
        bool Remove(RemoveCalendarInputModel inputModel);
        bool Create(CreateCalendarInputModel inputModel);
        List<UtCalander> FindCalendar(int userId, string mode, string startDate = null);
    }
}

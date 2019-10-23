using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hairdb.Areas.API.Model;
using Hairdb.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Hairdb.DAL.Entity;
using System.Security.Claims;

namespace Hairdb.Areas.API.Controllers
{
    [Area("API")]
    [ApiController]
    [Route("api/v1/calendar/")]
    public class CalendarController: Controller
    {
        /// <summary>
        /// Calendar Repository
        /// </summary>
        private ICalendarRepository _calendarRepository;
        private IUserRepository _userRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calendarRepository"></param>
        public CalendarController(ICalendarRepository calendarRepository,UserRepository userRepository)
        {
            _calendarRepository = calendarRepository;
            _userRepository = userRepository;
        }
        /// <summary>
        /// Add Event
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult Create([FromForm]CreateCalendarInputModel inputModel)
        {
            if (!this.TryValidateModel(inputModel))
            {
                return Ok(new ApiResultModel<int>(200, 10));
            }
            var row = _calendarRepository.Create(inputModel);
            int status = 0;
            if (row == null)
            {
                status = 1;
            }
            return Ok(new ApiResultModel<int>(200, status));
        }
        /// <summary>
        /// Remove Event
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("remove")]
        public ActionResult<ApiResultModel<int>> Remove([FromForm]RemoveCalendarInputModel inputModel)
        {
            if (!this.TryValidateModel(inputModel))
            {
                return Ok(new ApiResultModel<int>(200, 10));
            }

            bool row = _calendarRepository.Remove(inputModel);
            int status = 0;
            if (row == true) status = 1;
            return Ok(new ApiResultModel<int>(200, status));
        }
        /// <summary>
        /// Find event
        /// </summary>
        /// <param name="mode">ALL,DAY,FROM</param>
        /// <param name="date">ddMMyyyyhhmm</param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("find")]
        public ActionResult<ApiResultModel<List<UtCalander>>> FindCalendar([FromForm] string mode,[FromForm] string date)
        {

            var nameIdentifier = this.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (nameIdentifier == null)
            {
                return Ok(new ApiResultModel<int>(200, 2));
            }
            var profile = _userRepository.CheckLogin(nameIdentifier.Value);
            var row = _calendarRepository.FindCalendar(profile.Id, mode, date);
            return Ok(new ApiResultModel<List<UtCalander>>(200, row));
        }
    }
}

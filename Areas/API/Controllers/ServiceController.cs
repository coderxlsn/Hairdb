using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;
using Hairdb.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hairdb.Areas.API.Controllers
{
    [Authorize]
    [Area("API")]
    [ApiController]
    [Route("api/v1/service/")]
    public class ServiceController : Controller
    {
        private IServiceRepository _serviceRepository;
        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        /// <summary>
        /// Add service
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult<ApiResultModel<UtService>> Create([FromForm] string name, [FromForm] string phone)
        {
            var row = _serviceRepository.Create(name, phone);
            return Ok( new ApiResultModel<UtService>(200, row));
        }
        /// <summary>
        /// Remove service
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("remove")]
        public ActionResult<ApiResultModel<int>> Remove([FromForm] int id)
        {
            var row = _serviceRepository.Remove(id);
            return Ok(new ApiResultModel<int>(200,(row == true?0:1)));
        }
        /// <summary>
        /// Get All Service
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<ApiResultModel<List<UtService>>> GetAll() => Ok(new ApiResultModel<List<UtService>>(200, _serviceRepository.GetAll()));
    }
}

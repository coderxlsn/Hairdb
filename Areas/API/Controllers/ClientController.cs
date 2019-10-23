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
    [Route("api/v1/client/")]
    public class ClientController : Controller
    {
        private IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        /// <summary>
        /// Add client
        /// </summary>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult<ApiResultModel<UtClient>> Create([FromForm] string name, [FromForm] string phone)
        {
            var row = _clientRepository.Create(name, phone);
            return Ok( new ApiResultModel<UtClient>(200, row));
        }
        /// <summary>
        /// Remove client
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("remove")]
        public ActionResult<ApiResultModel<int>> Remove([FromForm] int id)
        {
            var row = _clientRepository.Remove(id);
            return Ok(new ApiResultModel<int>(200,(row == true?0:1)));
        }
        /// <summary>
        /// Get All Client
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getAll")]
        public ActionResult<ApiResultModel<List<UtClient>>> GetAll() => Ok(new ApiResultModel<List<UtClient>>(200, _clientRepository.GetAll()));
    }
}

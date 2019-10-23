using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hairdb.Areas.API.Model;
using Hairdb.DAL.Entity;
using Hairdb.DAL.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Hairdb.Areas.API.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Area("API")]
    [ApiController]
    [Route("api/v1/user/")]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="inputModel"></param>
        /// <response code="401" >Invalid token</response>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("create")]
        public ActionResult<ApiResultModel<int>> Create([FromForm]CreateUserInputModel inputModel)
        {
            
            if (!this.TryValidateModel(inputModel))
            {
                return Ok(new ApiResultModel<int>(200, 10));
            }
            var row = _userRepository.Create(inputModel);
            int status = 0;
            if(row == null)
            {
                status = 1;
            }
            return Ok(new ApiResultModel<int>(200, status));
        }
        /// <summary>
        /// Remove User
        /// </summary>
        /// <param name="inputModel"></param>
        /// <response code="401" >Invalid token</response>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Route("remove")]
        public ActionResult<ApiResultModel<int>> Remove([FromForm]RemoveUserInputModel inputModel)
        {
            if (!this.TryValidateModel(inputModel))
            {
                return Ok(new ApiResultModel<int>(200, 10));
            }

            bool row = _userRepository.Remove(inputModel);
            int status = 0;
            if (row == true) status = 1;
            return Ok(new ApiResultModel<int>(200, status));
        }
        /// <summary>
        /// List client
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getClients")]

        public ActionResult<ApiResultModel<List<string>>> GetClient()
        {
            var nameIdentifier = this.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if (nameIdentifier == null)
            {
                return Ok(new ApiResultModel<int>(200, 2));
            }
            var profile = _userRepository.CheckLogin(nameIdentifier.Value);
            return Ok(new ApiResultModel<List<string>>(200, _userRepository.GetClient(profile.UserGroupId)));
        }
        /// <summary>
        /// Get Profile
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Route("getProfile")]
        public ActionResult<ApiResultModel<UtUsers>> GetProfile()
        {

            var nameIdentifier = this.HttpContext.User.Claims
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            if(nameIdentifier == null)
            {
                return Ok(new ApiResultModel<int>(200, 2));
            }
            string username = nameIdentifier.Value;
            return Ok(new ApiResultModel<UtUsers>(200, _userRepository.CheckLogin(username)));
        }
    }
}

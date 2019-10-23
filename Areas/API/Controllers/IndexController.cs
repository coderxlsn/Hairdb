using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using Hairdb.DAL;
using Hairdb.DAL.Entity;
using Hairdb.Areas.API.Model;
using Hairdb.DAL.Repository;

namespace Hairdb.Areas.API.Controllers
{
    [Area("API")]
    [ApiController]
    [Route("api/v1/")]
    public class IndexController: Controller
    {
        private IUserRepository _userRepository;
        public IndexController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="model">Input Form</param>
        /// <returns></returns>
        /// <response code="401" >Invalid username or password</response>
        [HttpPost()]
        [Route("token")]
        [ProducesResponseType(typeof(ApiResultModel<string>),401)]
        [Produces("application/json")]
        public ActionResult<ApiResultModel<LoginModel>> Token([FromForm] LoginInputModel model)
        {

            ClaimsIdentity identity = GetIdentity(
                model.Username, model.Password);
            if (identity == null) return StatusCode(StatusCodes.Status401Unauthorized,
                                  new ApiResultModel<string>() { Status = 400, Result = "Invalid username or password." });
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            LoginModel response = new LoginModel
            {
                AccessToken = encodedJwt,
                Username = identity.Name
            };

            return Ok(new ApiResultModel<LoginModel>(200,response));
        }
        /// <summary>
        /// Проверка авторизации
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                UtUsers user = _userRepository.Login(username, password);
                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"),
                        new Claim(ClaimTypes.NameIdentifier,user.Username)
                    };
                    ClaimsIdentity claimsIdentity =
                        new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                            ClaimsIdentity.DefaultRoleClaimType);
                    return claimsIdentity;
                }
            }
            // если пользователя не найдено
            return null;
        }

    }
}

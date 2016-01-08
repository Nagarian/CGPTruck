using CGPTruck.Entities;
using CGPTruck.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace CGPTruck.WebAPI.Controllers
{
    /// <summary>
    /// Controller permettant de gérer toute l'authentification
    /// </summary>
    public class AuthController : ApiController
    {
        private BLL.Users usersMethods;

        public AuthController()
        {
            usersMethods = new BLL.Users();
        }

        // POST: api/auth/login
        /// <summary>
        /// Permet d'authentifier un utilisateur
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [ResponseType(typeof(string))]
        [System.Web.Http.HttpPost]
        public IHttpActionResult PostAuth([FromBody] AuthCredentialsModel credentials)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            User user = usersMethods.AuthenticateUser(credentials.Email, credentials.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(usersMethods.GenerateTokenForUser(user.Id));
        }
    }
}
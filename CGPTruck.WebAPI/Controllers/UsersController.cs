using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CGPTruck.WebAPI.Controllers
{
    /// <summary>
    /// Controller concernant les utilisateurs. Authentification requise
    /// </summary>
    [Authorize]
    public class UsersController : BaseController
    {
        private BLLUsers users = new BLLUsers();

        // GET: api/Users/Repairers/
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de tout les réparateurs
        /// </summary>
        /// <returns></returns>
        [Route("api/Users/Repairers/")]
        [HttpGet]
        [ResponseType(typeof(List<User>))]
        public IHttpActionResult GetPlaces()
        {
            if (CurrentUser.AccountType == AccountType.Repairer || CurrentUser.AccountType == AccountType.Driver)
            {
                return Unauthorized();
            }

            return Ok(users.GetRepairers().Select(u => u.RemoveProperty("AspNetId", "Phones", "RealPhone.Users")));
        }
    }
}

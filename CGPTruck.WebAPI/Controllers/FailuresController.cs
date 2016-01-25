using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Entities;
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
    /// Controller concernant les pannes. Authentification requise
    /// </summary>
    [Authorize]
    public class FailuresController : BaseController
    {
        private BLLFailures failures = new BLLFailures();

        // GET: api/Places
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de toutes les places
        /// </summary>
        /// <returns></returns>
        [Route("api/Failures/Declared")]
        [HttpGet]
        [ResponseType(typeof(List<Failure>))]
        public IHttpActionResult GetFailures()
        {
            if (CurrentUser.AccountType == AccountType.Repairer || CurrentUser.AccountType == AccountType.Driver)
            {
                return Unauthorized();
            }

            return Ok(failures.GetFailures());
        }
    }
}

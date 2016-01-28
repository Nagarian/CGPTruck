using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
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

        // GET: api/Failures
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de toutes les pannes
        /// </summary>
        /// <returns></returns>
        [Route("api/Failures/declared")]
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

        // POST : api/Failures/5
        /// <summary>
        /// Administrator/DecisionMaker : Assigne un réparateur à une panne
        /// </summary>
        /// <param name="failureId">ID de la panne</param>
        /// <param name="repairer">Réparateur assigné</param>
        /// <returns></returns>
        [Route("api/Failures/{failureId}/assign")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostFailureRepairerAssigned(int failureId, [FromBody] AssignedRepairerModel repairer)
        {
            if (CurrentUser.AccountType != AccountType.Administrator || CurrentUser.AccountType != AccountType.DecisionMaker)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                failures.AssignRepairerToFailure(failureId, repairer.RepairerId);
            }
            catch (ObjectNotFoundException)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST : api/Failures
        /// <summary>
        /// Repairer/Administrator/DecisionMaker : Met à jour le status d'une panne
        /// </summary>
        /// <param name="failureId">ID de la panne</param>
        /// <param name="repairer">Réparateur assigné</param>
        /// <returns></returns>
        [Route("api/Failures/{failureId}")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostFailure(int failureId, [FromBody] FailureModel failure)
        {
            if (CurrentUser.AccountType != AccountType.Administrator || CurrentUser.AccountType != AccountType.DecisionMaker || CurrentUser.AccountType != AccountType.Repairer)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
                        
            failures.UpdateFailure(failureId, failure);

            return Ok();
        }
    }
}

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
    /// Controller concernant les vehicules. Authentification requise
    /// </summary>
    [Authorize]
    public class VehiculesController : BaseController
    {
        private BLLVehicules vehicules = new BLLVehicules();

        // GET: api/Vehicules
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de tout les vehicules en fonction avec leur assignation actuelle
        /// </summary>
        /// <returns></returns>
        [Route("api/Vehicules/")]
        [HttpGet]
        [ResponseType(typeof(List<Vehicule>))]
        public IHttpActionResult GetVehicules()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }
            
            return Ok(vehicules.GetVehicules());
        }

        // GET: api/Vehicules/5
        /// <summary>
        /// Obtient tout les détails d'un vehicule
        /// </summary>
        /// <param name="vehiculeId">Id du vehicule dont on veut les détails</param>
        /// <returns>Vehicule avec toutes les informations le concernant</returns>
        [Route("api/Vehicules/{vehiculeId}")]
        [HttpGet]
        [ResponseType(typeof(Vehicule))]
        public IHttpActionResult GetVehicule(int vehiculeId)
        {
            Vehicule vehicule = vehicules.GetVehicule(vehiculeId);
            if (vehicule == null)
            {
                return NotFound();
            }
            else if (CurrentUser.AccountType == AccountType.Driver)
            {
                // TODO : on leur retourne ou pas ?
            }
            else if (CurrentUser.AccountType == AccountType.DecisionMaker)
            {
                // TODO : on leur retourne ou pas ?
            }
            else if (CurrentUser.AccountType == AccountType.Repairer)
            {
                // TODO : on leur retourne ou pas ?
            }

            return Ok(vehicule);
        }

    }
}

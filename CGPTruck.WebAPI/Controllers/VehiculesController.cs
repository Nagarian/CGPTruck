using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Models;
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

        // POST: api/Vehicules/5/Position
        /// <summary>
        /// Driver : Met à jour la position du vehicule actuel
        /// </summary>
        /// <param name="vehiculeId">ID du vehicule</param>
        /// <param name="position">Nouvelle position</param>
        /// <returns></returns>
        [Route("api/Vehicules/{vehiculeId}/Position")]
        [HttpPost]
        [ResponseType(typeof(void))]
        public IHttpActionResult PostVehiculePosition(int vehiculeId, [FromBody] PositionModel position)
        {
            if (CurrentUser.AccountType != AccountType.Driver)
            {
                return Unauthorized();
            }

            var driver = vehicules.GetVehiculeCurrentDriver(vehiculeId);
            if (CurrentUser.Id != driver.Id)
            {
                return Unauthorized();
            }

            if (vehicules.UpdateVehiculePosition(vehiculeId, new Position { Latitude = position.Latitude, Longitude = position.Longitude }))
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}

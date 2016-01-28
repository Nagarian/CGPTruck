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
        [Route("api/Vehicules")]
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


        // GET: api/Vehicules/grouped
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de tout les vehicules groupé par leur assignation actuelle
        /// </summary>
        /// <returns></returns>
        [Route("api/Vehicules/grouped")]
        [HttpGet]
        [ResponseType(typeof(GroupedVehiculesModel))]
        public IHttpActionResult GetGroupedVehicules()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }

            return Ok(vehicules.GetVehiculeGrouped());
        }


        // GET: api/Vehicules/truck
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de tout les camions disponible
        /// </summary>
        /// <returns></returns>
        [Route("api/Vehicules/truck")]
        [HttpGet]
        [ResponseType(typeof(List<Vehicule>))]
        public IHttpActionResult GetTrucks()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }

            return Ok(vehicules.GetVehiculesOfType(VehiculeType.Truck));
        }

        // GET: api/Vehicules/repairtruck
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de tout les camions de réparateurs disponible
        /// </summary>
        /// <returns></returns>
        [Route("api/Vehicules/repairtruck")]
        [HttpGet]
        [ResponseType(typeof(List<Vehicule>))]
        public IHttpActionResult GetRepairtrucks()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }

            return Ok(vehicules.GetVehiculesOfType(VehiculeType.RepairTruck));
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
        /// Driver/Repairer : Met à jour la position du vehicule actuel
        /// </summary>
        /// <param name="vehiculeId">ID du vehicule</param>
        /// <param name="position">Nouvelle position</param>
        /// <returns></returns>
        [Route("api/Vehicules/{vehiculeId}/position")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehiculePosition(int vehiculeId, [FromBody] PositionModel position)
        {
            if (CurrentUser.AccountType != AccountType.Driver || CurrentUser.AccountType != AccountType.Repairer)
            {
                return Unauthorized();
            }

            Utils.QueueManager.Current.SendPosition(vehiculeId, new Position { Latitude = position.Latitude, Longitude = position.Longitude });
            return Ok();

            var driver = vehicules.GetVehiculeCurrentDriver(vehiculeId);

            if (driver == null)
            {
                ModelState.AddModelError("vehiculeId", "You can't update position of an unaffected vehicule.");
                return BadRequest(ModelState);
            }

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

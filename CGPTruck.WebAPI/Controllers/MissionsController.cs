using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Models;

namespace CGPTruck.WebAPI.Controllers
{
    /// <summary>
    /// Controller concernant les missions. Authentification requise
    /// </summary>
    [Authorize]
    public class MissionsController : BaseController
    {
        private CGPTruckEntities db = new CGPTruckEntities();
        private BLLMissions missions = new BLLMissions();

        /// <summary>
        /// Conducteur : Obtiens les missions du jour et celle à venir
        /// </summary>
        /// <returns>Liste des missions du jours et à venir</returns>
        [Route("api/Missions/my")]
        [HttpGet]
        [ResponseType(typeof(List<Mission>))]
        public IHttpActionResult GetMyMission()
        {
            if (CurrentUser.AccountType != AccountType.Driver)
            {
                return Unauthorized();
            }

            var list = missions.GetMissionsOfDriver(CurrentUser.Id);
            if (list == null)
            {
                return BadRequest();
            }

            return Ok(list);
        }


        // GET: api/Missions
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de toutes les missions
        /// </summary>
        /// <returns></returns>
        [Route("api/Missions")]
        [HttpGet]
        [ResponseType(typeof(List<Mission>))]
        public IHttpActionResult GetMissions()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }

            return Ok(missions.GetMissions());
        }

        // GET: api/Missions/active
        /// <summary>
        /// Administrator/DecisionMaker : Obtient la liste de toutes les missions actives et à venir
        /// </summary>
        /// <returns></returns>
        [Route("api/Missions/active")]
        [HttpGet]
        [ResponseType(typeof(List<Mission>))]
        public IHttpActionResult GetActiveMissions()
        {
            if (CurrentUser.AccountType == AccountType.Driver || CurrentUser.AccountType == AccountType.Repairer)
            {
                return Unauthorized();
            }

            return Ok(missions.GetActiveMissions());
        }

        // GET: api/Missions/5
        /// <summary>
        /// Obtient tout les détails d'une mission
        /// Driver : Ne peux obtenir que les détails des missions qui lui on été assigné
        /// </summary>
        /// <param name="missionId">Id de la mission dont on veut les détails</param>
        /// <returns>Mission avec toutes les informations la concernant</returns>
        [Route("api/Missions/{missionId}", Name = "GetMission")]
        [HttpGet]
        [ResponseType(typeof(Mission))]
        public IHttpActionResult GetMission(int missionId)
        {
            Mission mission = missions.GetMissionFullDetail(missionId);
            if (mission == null)
            {
                return NotFound();
            }
            else if (CurrentUser.AccountType == AccountType.Driver && mission.Driver_Id != CurrentUser.Id)
            {
                return Unauthorized();
            }
            else if (CurrentUser.AccountType == AccountType.DecisionMaker)
            {
                // TODO : on leur retourne ou pas ?
            }
            else if (CurrentUser.AccountType == AccountType.Repairer)
            {
                // TODO : on leur retourne ou pas ?
            }

            return Ok(mission);
        }

        // GET: api/Missions/5
        /// <summary>
        /// Obtient tout les étapes effectuées d'une mission
        /// Driver : Ne peux obtenir que les étapes des missions qui lui on été assigné
        /// </summary>
        /// <param name="missionId">Id de la mission dont on veut les détails</param>
        /// <returns>Liste des étapes de la mission</returns>
        [Route("api/Missions/{missionId}/steps")]
        [HttpGet]
        [ResponseType(typeof(List<Step>))]
        public IHttpActionResult GetMissionSteps(int missionId)
        {
            if (CurrentUser.AccountType == AccountType.Driver && missions.GetMissionDriver(missionId).Id != CurrentUser.Id)
            {
                return Unauthorized();
            }
            else if (CurrentUser.AccountType == AccountType.DecisionMaker)
            {
                // TODO : on leur retourne ou pas ?
            }
            else if (CurrentUser.AccountType == AccountType.Repairer)
            {
                // TODO : on leur retourne ou pas ?
            }

            List<Step> steps = missions.GetMissionSteps(missionId);
            if (steps == null)
            {
                return NotFound();
            }

            return Ok(steps);
        }

        // GET: api/Missions/5
        /// <summary>
        /// Administrator/DecisionMaker : Obtient tout les pannes survenues lors d'une mission
        /// Repairer : Ne peux obtenir que les pannes survenues qui lui on été assigné
        /// </summary>
        /// <param name="missionId">Id de la mission dont on veut les détails</param>
        /// <returns>Liste des pannes survenues lors de la mission</returns>
        [Route("api/Missions/{missionId}/failures")]
        [HttpGet]
        [ResponseType(typeof(List<Failure>))]
        public IHttpActionResult GetMissionFailures(int missionId)
        {
            if (CurrentUser.AccountType == AccountType.Driver)
            {
                return Unauthorized();
            }

            List<Failure> failures = missions.GetMissionFailure(missionId);
            if (failures == null)
            {
                return NotFound();
            }
            else if (CurrentUser.AccountType == AccountType.Repairer && failures?.FirstOrDefault()?.Repairer_Id != CurrentUser.Id)
            {
                return Unauthorized();
            }

            return Ok(failures);
        }

        // POST: api/Missions
        /// <summary>
        /// Administrator/DecisionMaker : Ajoute une nouvelle mission
        /// </summary>
        /// <param name="mission"></param>
        /// <returns></returns>
        [Route("api/Missions")]
        [HttpPost]
        [ResponseType(typeof(Mission))]
        public IHttpActionResult PostMission([FromBody] MissionModel mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (mission.Date < DateTime.Today)
            {
                ModelState.AddModelError("Date", "It's not a valid date");
            }

            var vehicule = BLLVehicules.Current.GetVehicule(mission.Vehicule_Id);

            if (vehicule.Vehicule_Type != VehiculeType.Truck)
            {
                ModelState.AddModelError("Vehicule_Id", "It's not a valid vehicule");
            }

            var driver = BLLUsers.Current.GetUserInformations(mission.Driver_Id);

            if (driver.AccountType != AccountType.Driver)
            {
                ModelState.AddModelError("Driver_Id", "It's not a valid driver");
            }

            var pickuplace = BLLPlaces.Current.GetPlace(mission.Pickup_Place_Id);

            if (pickuplace.Place_Type != PlaceType.Warehouse)
            {
                ModelState.AddModelError("Pickup_Place_Id", "It's not a valid warehouse");
            }

            var deliveryPlace = BLLPlaces.Current.GetPlace(mission.Delivery_Place_Id);

            if (deliveryPlace.Place_Type != PlaceType.Client)
            {
                ModelState.AddModelError("Delivery_Place_Id", "It's not a valid client");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMission = missions.AddMission(new Mission
            {
                Attachments = null,
                Date = mission.Date,
                Delivery_Place_Id = mission.Delivery_Place_Id,
                Description = mission.Description,
                Driver_Id = mission.Driver_Id,
                Name = mission.Name,
                Pickup_Place_Id = mission.Pickup_Place_Id,
                Steps = new List<Step>
                {
                    new Step
                    {
                        Date = DateTime.Now,
                        Informations = "RAS",
                        Position = new Position
                        {
                            Latitude = vehicule.Position.Latitude,
                            Longitude = vehicule.Position.Longitude
                        },
                        StepNumber = 0,
                        Step_Type = StepType.Waiting
                    },
                },
                Vehicule_Id = mission.Vehicule_Id
            });

            return CreatedAtRoute("GetMission", new { missionId = newMission.Id }, newMission);
        }

        // PUT: api/Missions/5/steps
        /// <summary>
        /// Driver : Ajoute une étape à une mission qui est en cours
        /// </summary>
        /// <param name="missionId">Id de la mission dont on veut rajouter une étape</param>
        /// <param name="step">Etape à insérer</param>
        [Route("api/Missions/{missionId}/steps")]
        [HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStep(int missionId, StepModel step)
        {
            if (CurrentUser.AccountType != AccountType.Driver)
            {
                return Unauthorized();
            }

            Mission mission = missions.GetMission(missionId);

            if (mission.Driver_Id != CurrentUser.Id)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Step lastStep = mission.Steps.OrderByDescending(s => s.StepNumber).FirstOrDefault();

            if (lastStep != null)
            {
                if (lastStep.StepNumber > step.StepNumber)
                {
                    return BadRequest("Bad StepNumber");
                }

                if (lastStep.Step_Type == StepType.Aborted || lastStep.Step_Type == StepType.Finished)
                {
                    return BadRequest("Mission was over");
                }
            }

            Step newStep = new Step
            {
                Date = step.Date,
                Informations = string.IsNullOrEmpty(step.Informations) ? "RAS" : step.Informations,
                Mission_Id = missionId,
                Position = new Position
                {
                    Latitude = step.Position.Latitude,
                    Longitude = step.Position.Longitude
                },
                StepNumber = step.StepNumber,
                Step_Type = step.Step_Type
            };

            missions.AddStepToMission(missionId, newStep);

            return StatusCode(HttpStatusCode.NoContent);
        }
        //// PUT: api/Missions/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutMission(int id, Mission mission)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != mission.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(mission).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MissionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// DELETE: api/Missions/5
        //[ResponseType(typeof(Mission))]
        //public IHttpActionResult DeleteMission(int id)
        //{
        //    Mission mission = db.Missions.Find(id);
        //    if (mission == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Missions.Remove(mission);
        //    db.SaveChanges();

        //    return Ok(mission);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool MissionExists(int id)
        //{
        //    return db.Missions.Count(e => e.Id == id) > 0;
        //}
    }
}
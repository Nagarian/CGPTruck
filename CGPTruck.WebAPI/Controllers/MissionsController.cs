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

namespace CGPTruck.WebAPI.Controllers
{
    [Authorize]
    public class MissionsController : BaseController
    {
        private CGPTruckEntities db = new CGPTruckEntities();
        private BLLMissions missions = new BLLMissions();

        /// <summary>
        /// Obtiens les missions du jour et celle à venir
        /// </summary>
        /// <returns>Liste des missions du jours et à venir</returns>
        [Route("api/Missions/my")]
        [ResponseType(typeof(List<Mission>))]
        public IHttpActionResult GetMyMission()
        {            
            var list = missions.GetMissionOfDriver(CurrentUser.Id);
            if (list == null)
            {
                return BadRequest();
            }

            return Ok(list);
        }


        // GET: api/Missions
        [ResponseType(typeof(List<Mission>))]
        public IHttpActionResult GetMissions()
        {
            return Ok((from mission in db.Missions.Include(m => m.DeliveryPlace)
                                              .Include("PickupPlace")
                       select mission).ToList());
        }



        // GET: api/Missions/5
        [ResponseType(typeof(Mission))]
        public IHttpActionResult GetMission(int id)
        {
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return NotFound();
            }

            return Ok(mission);
        }

        // PUT: api/Missions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMission(int id, Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mission.Id)
            {
                return BadRequest();
            }

            db.Entry(mission).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Missions
        [ResponseType(typeof(Mission))]
        public IHttpActionResult PostMission(Mission mission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Missions.Add(mission);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mission.Id }, mission);
        }

        // DELETE: api/Missions/5
        [ResponseType(typeof(Mission))]
        public IHttpActionResult DeleteMission(int id)
        {
            Mission mission = db.Missions.Find(id);
            if (mission == null)
            {
                return NotFound();
            }

            db.Missions.Remove(mission);
            db.SaveChanges();

            return Ok(mission);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MissionExists(int id)
        {
            return db.Missions.Count(e => e.Id == id) > 0;
        }
    }
}
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;


namespace CGPTruck.WebAPI.BLL
{
    public class BLLMissions
    {
        /// <summary>
        /// Méthode pour obtenir la liste des missions du jour et à venir
        /// </summary>
        /// <param name="userId">ID du conducteur</param>
        /// <returns>Liste des missions disponibles du conducteur</returns>
        public List<Mission> GetMissionOfDriver(int userId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps)
                                                        .Include("Steps.Position")
                                                        .Include(m => m.Attachments)
                                                        .Include(m => m.Vehicule.Position)
                        where mission.Driver_Id == userId && mission.Date >= DateTime.Today
                        orderby mission.Date ascending
                        select mission).ToList();
            }
        }
        
    }
}
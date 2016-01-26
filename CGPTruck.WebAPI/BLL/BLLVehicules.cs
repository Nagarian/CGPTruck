using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.BLL
{
    /// <summary>
    /// Business Logic Layer des vehicules
    /// </summary>
    public class BLLVehicules
    {
        /// <summary>
        /// Permet d'obtenir une instance rapidement
        /// </summary>
        public static BLLVehicules Current { get; set; } = new BLLVehicules();


        /// <summary>
        /// Permet d'obtenir les détails d'une vehicule
        /// </summary>
        /// <param name="vehiculeId">ID du vehicule</param>
        /// <returns></returns>
        public Vehicule GetVehicule(int vehiculeId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from vehicule in context.Vehicules.Include(v => v.Position)
                                                          .Include(v => v.Reparations)
                                                          .Include(v => v.Failures)
                                                          .Include(v => v.Missions)
                        where vehicule.Id == vehiculeId
                        select vehicule).SingleOrDefault();
            }
        }

        /// <summary>
        /// Permet d'obtenir tout les vehicules de la BDD
        /// </summary>
        /// <returns></returns>
        public List<Vehicule> GetVehicules()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var result = (from vehicule in context.Vehicules.Include(v => v.Position)
                                                                .Include(v => v.Reparations)
                                                                .Include(v => v.Missions.Select(m => m.Steps))
                                  //let failures = vehicule.Reparations.OrderByDescending(f => f.Date).Take(1)
                              where vehicule.Vehicule_State != VehiculeState.OutOfService
                              select vehicule).ToList();

                // TODO : perfs ultra pourris :D
                foreach (var v in result)
                {
                    if (v.Vehicule_Type == VehiculeType.RepairTruck)
                    {
                        v.Reparations = v.Reparations.Where(r => r.State != FailureState.Resolved).ToList();
                    }
                    else if (v.Vehicule_Type == VehiculeType.Truck)
                    {
                        v.Missions = v.Missions.Where(m => !m.Steps.Any(s => s.Step_Type == StepType.Aborted || s.Step_Type == StepType.Finished)).ToList();
                    }
                }

                return result;
            }
        }


        /// <summary>
        /// Permet d'obtenir tout les vehicules du type spécifié fonctionnel
        /// </summary>
        /// <returns></returns>
        public List<Vehicule> GetVehiculesOfType(VehiculeType vehiculeType)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from vehicule in context.Vehicules
                        where vehicule.Vehicule_State != VehiculeState.Running && vehicule.Vehicule_Type == vehiculeType
                        select vehicule).ToList();
            }
        }

        /// <summary>
        /// Permet d'obtenir le conducteur actuel d'un vehicule
        /// </summary>
        /// <param name="vehiculeId">ID du véhicule</param>
        /// <returns></returns>
        public User GetVehiculeCurrentDriver(int vehiculeId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var driver = (from vehicule in context.Vehicules
                              where vehicule.Id == vehiculeId
                              from mission in vehicule.Missions
                              let lastStep = mission.Steps.OrderByDescending(s => s.StepNumber).FirstOrDefault()
                              where mission.Date == DateTime.Today && mission.Steps.Count > 0 && lastStep.Step_Type != StepType.Aborted && lastStep.Step_Type != StepType.Failure
                              select mission.Driver).SingleOrDefault();
                return driver;
            }
        }

        /// <summary>
        /// Permet de mettre à jour la position d'un vehicule
        /// </summary>
        /// <param name="vehiculeId">ID du vehicule</param>
        /// <param name="position">Nouvelle position</param>
        /// <returns>Indique si la mise à jour à réussi</returns>
        public bool UpdateVehiculePosition(int vehiculeId, Position position)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var veh = (from vehicule in context.Vehicules.Include(v => v.Position)
                           where vehicule.Id == vehiculeId
                           select vehicule).SingleOrDefault();
                if (veh == null)
                {
                    return false;
                }

                if (veh.Position == null)
                {
                    veh.Position = new Position { Latitude = position.Latitude, Longitude = position.Longitude };
                }
                else
                {
                    veh.Position.Latitude = position.Latitude;
                    veh.Position.Longitude = position.Longitude;
                }

                context.SaveChanges();
                return true;
            }
        }
    }
}
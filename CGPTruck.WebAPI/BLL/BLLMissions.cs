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
    /// <summary>
    /// Business Logic Layer des missions
    /// </summary>
    public class BLLMissions
    {
        /// <summary>
        /// Permet d'obtenir une instance rapidement
        /// </summary>
        public static BLLMissions Current { get; set; } = new BLLMissions();

        /// <summary>
        /// Méthode pour obtenir la liste des missions du jour et à venir
        /// </summary>
        /// <param name="userId">ID du conducteur</param>
        /// <returns>Liste des missions disponibles du conducteur</returns>
        public List<Mission> GetMissionsOfDriver(int userId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Attachments)
                                                        .Include(m => m.Vehicule.Position)
                        where mission.Driver_Id == userId && mission.Date >= DateTime.Today
                        orderby mission.Date ascending
                        select mission).ToList();
            }
        }

        /// <summary>
        /// Permet d'obtenir toutes les missions de la BDD
        /// </summary>
        /// <returns></returns>
        public List<Mission> GetMissions()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Vehicule.Position)
                        orderby mission.Date ascending
                        select mission).ToList();
            }
        }

        /// <summary>
        /// Permet d'obtenir toutes les missions de la BDD du jour et à suivre
        /// </summary>
        /// <returns></returns>
        public List<Mission> GetActiveMissions()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Vehicule.Position)
                        where mission.Date >= DateTime.Today && mission.Steps.Count > 0
                        orderby mission.Date ascending
                        select mission).ToList();
            }
        }

        /// <summary>
        /// Permet d'obtenir les détails d'une mission
        /// </summary>
        /// <param name="missionId">ID de la mission</param>
        /// <returns></returns>
        public Mission GetMission(int missionId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var result = (from mission in context.Missions.Include(m => m.DeliveryPlace)
                                                        .Include(m => m.PickupPlace)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Vehicule)
                                                        .Include(m => m.Driver)
                                                        .Include(m => m.Attachments)
                                                        .Include(m => m.Failures)
                              where mission.Id == missionId
                              select mission).SingleOrDefault();

                if (result != null && result.Steps != null)
                {
                    result.Steps = result.Steps.OrderByDescending(s => s.StepNumber).ToList();
                }

                return result;
            }
        }

        /// <summary>
        /// Permet d'obtenir le conducteur assigné à une mission
        /// </summary>
        /// <param name="missionId">ID de la mission</param>
        /// <returns></returns>
        public User GetMissionDriver(int missionId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {

                return (from mission in context.Missions
                        where mission.Id == missionId
                        select mission.Driver).SingleOrDefault();
            }
        }

        /// <summary>
        /// Permet d'obtenir tout les détails d'une mission
        /// </summary>
        /// <param name="missionId">ID de la mission</param>
        /// <returns></returns>
        public Mission GetMissionFullDetail(int missionId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var result = (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Vehicule.Position)
                                                        .Include(m => m.Driver)
                                                        .Include(m => m.Attachments)
                                                        .Include(m => m.Failures.Select(f => f.Repairer))
                                                        .Include(m => m.Failures.Select(f => f.RepairerVehicule))
                                                        .Include(m => m.Failures.Select(f => f.FailureDetail.Attachments))
                              where mission.Id == missionId
                              select mission).SingleOrDefault();

                if (result != null && result.Steps != null)
                {
                    result.Steps = result.Steps.OrderByDescending(s => s.StepNumber).ToList();
                }

                return result;
            }
        }

        /// <summary>
        /// Permet d'obtenir toutes les étapes d'une mission
        /// </summary>
        /// <param name="missionId">ID de la mission</param>
        /// <returns></returns>
        public List<Step> GetMissionSteps(int missionId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from step in context.Steps.Include(s => s.Position)
                        where step.Mission_Id == missionId
                        orderby step.StepNumber descending
                        select step).ToList();
            }
        }

        /// <summary>
        /// Permet d'obtenir toutes les pannes survenues durant une missions
        /// </summary>
        /// <param name="missionId">ID de la mission</param>
        /// <returns></returns>
        public List<Failure> GetMissionFailure(int missionId)
        {
            // TODO : trouver un moyen pour y inclure le step correspondant pour avoir la position de la panne ???
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from failure in context.Failures.Include(f => f.Vehicule)
                                                        .Include(f => f.Mission)
                                                        .Include(f => f.Mission.Driver)
                                                        .Include(f => f.Repairer)
                                                        .Include(f => f.RepairerVehicule)
                                                        .Include(f => f.FailureDetail.Attachments)
                        where failure.Mission_id == missionId
                        select failure).ToList();
            }
        }


        // La même méthode que GetMissions mais en allégeant la requête pour garder seulement le dernier Step
        // Je ne suis pas sûr que ça soit la manière la plus optimale
        //public List<Mission> GetMissionsLight()
        //{
        //    using (CGPTruckEntities context = new CGPTruckEntities())
        //    {
        //        var toto = (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
        //                                                .Include(m => m.PickupPlace.Position)
        //                                                .Include(m => m.Steps.Select(s => s.Position))
        //                                                .Include(m => m.Vehicule.Position)
        //                    orderby mission.Date ascending
        //                    let step = mission.Steps.OrderByDescending(s => s.StepNumber).FirstOrDefault()
        //                    select new
        //                    {
        //                        Id = mission.Id,
        //                        Date = mission.Date,
        //                        DeliveryPlace = new
        //                        {
        //                            Id = mission.DeliveryPlace.Id,
        //                            Active = mission.DeliveryPlace.Active,
        //                            Name = mission.DeliveryPlace.Name,
        //                            Place_Type = mission.DeliveryPlace.Place_Type,
        //                            Position = mission.DeliveryPlace.Position
        //                        },
        //                        Driver = mission.Driver,
        //                        Name = mission.Name,
        //                        PickupPlace = new
        //                        {
        //                            Id = mission.PickupPlace.Id,
        //                            Active = mission.PickupPlace.Active,
        //                            Name = mission.PickupPlace.Name,
        //                            Place_Type = mission.PickupPlace.Place_Type,
        //                            Position = mission.PickupPlace.Position
        //                        },
        //                        Step = step == null ? null : new
        //                        {
        //                            Id = step.Id,
        //                            Date = step.Date,
        //                            Position = step.Position,
        //                            StepNumber = step.StepNumber,
        //                            Step_Type = step.Step_Type,
        //                        },
        //                        Vehicule = new
        //                        {
        //                            Id = mission.Vehicule.Id,
        //                            Vehicule_Type = mission.Vehicule.Vehicule_Type,
        //                            Vehicule_State = mission.Vehicule.Vehicule_State,
        //                            Position = mission.Vehicule.Position,
        //                        }
        //                    }).AsEnumerable();
        //        return (from mission in toto
        //                select new Mission
        //                {
        //                    Id = mission.Id,
        //                    Date = mission.Date,
        //                    DeliveryPlace = new Place
        //                    {
        //                        Id = mission.DeliveryPlace.Id,
        //                        Active = mission.DeliveryPlace.Active,
        //                        Name = mission.DeliveryPlace.Name,
        //                        Place_Type = mission.DeliveryPlace.Place_Type,
        //                        Position = mission.DeliveryPlace.Position,
        //                        Position_Id = mission.DeliveryPlace.Position.Id
        //                    },
        //                    Driver = mission.Driver,
        //                    Name = mission.Name,
        //                    PickupPlace = new Place
        //                    {
        //                        Id = mission.PickupPlace.Id,
        //                        Active = mission.PickupPlace.Active,
        //                        Name = mission.PickupPlace.Name,
        //                        Place_Type = mission.PickupPlace.Place_Type,
        //                        Position = mission.PickupPlace.Position,
        //                        Position_Id = mission.PickupPlace.Position.Id
        //                    },
        //                    Steps = mission.Step == null ? new List<Step>() : new List<Step>
        //                    {
        //                        new Step
        //                        {
        //                            Id = mission.Step.Id,
        //                            Date = mission.Step.Date,
        //                            Position = mission.Step.Position,
        //                            Position_Id = mission.Step.Id,
        //                            StepNumber = mission.Step.StepNumber,
        //                            Step_Type = mission.Step.Step_Type,
        //                        }
        //                    },
        //                    Vehicule = new Vehicule
        //                    {
        //                        Id = mission.Vehicule.Id,
        //                        Vehicule_Type = mission.Vehicule.Vehicule_Type,
        //                        Vehicule_State = mission.Vehicule.Vehicule_State,
        //                        Position = mission.Vehicule.Position,
        //                        Position_Id = mission.Vehicule.Id
        //                    },
        //                    Vehicule_Id = mission.Vehicule.Id
        //                }).ToList();
        //    }
        //}
    }
}
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

        public List<Mission> GetActiveMissions()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from mission in context.Missions.Include(m => m.DeliveryPlace.Position)
                                                        .Include(m => m.PickupPlace.Position)
                                                        .Include(m => m.Steps.Select(s => s.Position))
                                                        .Include(m => m.Attachments)
                                                        .Include(m => m.Vehicule.Position)
                        where mission.Date >= DateTime.Today && mission.Steps.Count > 0
                        orderby mission.Date ascending
                        select mission).ToList();
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
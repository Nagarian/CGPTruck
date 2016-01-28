using CGPTruck.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    public class GroupedVehiculesModel
    {
        /// <summary>
        /// Camions en missions
        /// </summary>
        public List<Vehicule> TruckInMission { get; set; }

        /// <summary>
        /// Camions en missions - En panne
        /// </summary>
        public List<Vehicule> TruckInFailure { get; set; }

        /// <summary>
        /// Camions au garage
        /// </summary>
        public List<Vehicule> TruckInGarage { get; set; }

        /// <summary>
        /// Voitures de réparations
        /// </summary>
        public List<Vehicule> RepairTruck { get; set; }

        /// <summary>
        /// Voiture de réparations - Missions
        /// </summary>
        public List<Vehicule> RepairTruckInMission { get; set; }
    }
}
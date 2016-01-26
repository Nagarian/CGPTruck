using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations pour ajouter une nouvelle mission
    /// </summary>
    public class MissionModel
    {
        /// <summary>
        /// Nom de la mission
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description de la mission
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date de la mission
        /// </summary>
        [DataType(DataType.Date)]
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// ID du vehicule assigné à la mission
        /// </summary>
        [Required]
        public int Vehicule_Id { get; set; }

        /// <summary>
        /// ID du conducteur assigné à la mission
        /// </summary>
        [Required]
        public int Driver_Id { get; set; }

        /// <summary>
        /// ID du lieu où prendre la marchandise
        /// </summary>
        [Required]
        public int Pickup_Place_Id { get; set; }

        /// <summary>
        /// ID de la destination de la marchandise
        /// </summary>
        [Required]
        public int Delivery_Place_Id { get; set; }
        
        /// <summary>
        /// Liste contenant tout les documents annexes à la mission
        /// </summary>
        public List<AttachmentMissionModel> Attachments { get; set; }
    }
}
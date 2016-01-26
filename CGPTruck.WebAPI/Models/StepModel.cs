using CGPTruck.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Détail de l'étape
    /// </summary>
    public class StepModel
    {
        /// <summary>
        /// Date et heure de l'étape
        /// </summary>
        [Required]
        [Display(Name = "Date")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Détails de l'étape
        /// </summary>
        public string Informations { get; set; }

        /// <summary>
        /// Coordonnées GPS de l'étape
        /// </summary>
        [Required]
        public PositionModel Position { get; set; }

        /// <summary>
        /// Numéro de l'étape
        /// </summary>
        [Required]
        [Range(typeof(int), "0", "20")]
        public int StepNumber { get; set; }

        /// <summary>
        /// Type d'étape
        /// </summary>
        [Required]
        [EnumDataType(typeof(StepType))]
        public StepType Step_Type { get; set; }
    }
}
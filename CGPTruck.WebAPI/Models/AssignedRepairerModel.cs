using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations de l'assignation
    /// </summary>
    public class AssignedRepairerModel
    {
        /// <summary>
        /// ID du réparateur assigné
        /// </summary>
        [Required]
        [Display(Name = "ID du réparateur")]
        public int RepairerId { get; set; }
    }
}
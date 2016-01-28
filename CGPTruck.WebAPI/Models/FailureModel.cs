using CGPTruck.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations pour ajouter une nouvelle panne
    /// </summary>
    public class FailureModel
    {
        /// <summary>
        /// Etat de la panne
        /// </summary>
        [Required]
        public FailureState State { get; set; }

        /// <summary>
        /// Detail supplémentaire concernant la panne
        /// </summary>
        public FailureDetail FailureDetail { get; set; }
    }
}
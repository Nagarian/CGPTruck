using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Coordonnées GPS
    /// </summary>
    public class PositionModel
    {
        /// <summary>
        /// Latitude
        /// </summary>
        [Required]
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [Required]
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
    }
}
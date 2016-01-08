using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations nécessaire à l'authentification
    /// </summary>
    public class AuthCredentialsModel
    {
        /// <summary>
        /// Email de l'utilisateur
        /// </summary>
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        /// <summary>
        /// Password de l'utilisateur
        /// </summary>
        [Required(ErrorMessage = "The password is required")]
        public string Password { get; set; }
    }
}
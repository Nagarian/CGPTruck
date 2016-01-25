using CGPTruck.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations du nouvel utilisateur à insérer en BDD
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Pseudo de l'utilisateur
        /// </summary>
        [Required]
        [Display(Name = "Pseudo")]
        public string UserName { get; set; }

        /// <summary>
        /// Prénom de l'utilisateur
        /// </summary>
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        /// <summary>
        /// Nom de l'utilisateur
        /// </summary>
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        /// <summary>
        /// Date de naissance de l'utilisateur
        /// </summary>
        [Required]
        [Display(Name = "Date de naissance")]
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy")]
        public DateTime BirthdayDate  { get; set; }

        /// <summary>
        /// Sexe de l'utilisateur, Homme : true, Femme : false
        /// </summary>
        [Required]
        [Display(Name = "Sexe")]
        public bool Sexe { get; set; }

        /// <summary>
        /// Type de compte
        /// </summary>
        [Required]
        [Display(Name = "Type de compte")]
        public AccountType AccountType { get; set; }

        /// <summary>
        /// Type de permis de conduire de l'utilisateur
        /// </summary>
        [Required]
        [Display(Name = "Type de permis de l'utilisateur")]
        public DriverLicenseType DriverLicenseType { get; set; }
        
        /// <summary>
        /// Mot de passe de l'utilisateur
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Confirmation du mot de passe de l'utilisateur
        /// </summary>
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
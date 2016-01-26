using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Utilisateur
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Téléphone de l'utilisateur
        /// </summary>
        public Phone RealPhone
        {
            get
            {
                return Phones?.FirstOrDefault();
            }

            set
            {
                Phones = new List<Phone> { value };
            }
        }
    }
}
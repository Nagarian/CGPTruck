using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Models
{
    /// <summary>
    /// Informations composant une pièce jointe à une mission
    /// </summary>
    public class AttachmentMissionModel
    {
        /// <summary>
        /// Nom de la pièce jointe
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Description de la pièces jointes
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Chemin
        /// </summary>
        public string Path { get; set; }
    }
}
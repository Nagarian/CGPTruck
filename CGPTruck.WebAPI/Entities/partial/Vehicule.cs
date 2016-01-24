using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Objet réprésentant un véhicule
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{" +nameof(Id) + "} : {" + nameof(Vehicule_Type) + ",nq}<{" + nameof(Brand) + ",nq} - {" + nameof(Model) + ",nq}> ({" + nameof(Position) + ".Latitude}, {" + nameof(Position) + ".Longitude}) {" + nameof(Vehicule_State) + "}")]
    public partial class Vehicule
    {
        // Petit exemple montrant comment rajouter des propriétés ou des méthodes sur nos objets provenant de la BDD.
        // of course, les propriétés ajoutés ici ne seront pas automatiquement ajouter en tant que colonne dans la BDD :P
    }
}
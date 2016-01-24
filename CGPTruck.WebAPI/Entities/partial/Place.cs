using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Lieux
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(Id) + "} : {" + nameof(Place_Type) + ",nq}<{" + nameof(Name) + ",nq}> ({" + nameof(Position) + ".Latitude}, {" + nameof(Position) + ".Longitude})")]
    public partial class Place
    {
    }
}
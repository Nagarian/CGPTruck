using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Coordonnées GPS
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(Latitude) + "}, {" + nameof(Longitude) + "}")]
    public partial class Position
    {
    }
}
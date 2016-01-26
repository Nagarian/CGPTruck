using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Etapes d'une mission
    /// </summary>
    [System.Diagnostics.DebuggerDisplay("{" + nameof(Id) + "} : {" + nameof(Step_Type) + "} ({" + nameof(Position) + ".Latitude}, {" + nameof(Position) + ".Longitude})")]
    public partial class Step
    {
        /// <summary>
        /// Obtient les détails d'un StepType
        /// </summary>
        public StepTypeDetail StepTypeDetail
        {
            get
            {
                return new StepTypeDetail(this.Step_Type);
            }
        }

    }
}
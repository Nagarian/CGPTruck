using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Version Littéraire des StepType
    /// </summary>
    public class StepTypeDetail
    {
        [JsonIgnore]
        private StepType stepType;

        /// <summary>
        /// Créer les détails d'un StepType donné
        /// </summary>
        /// <param name="stepType"></param>
        public StepTypeDetail(StepType stepType)
        {
            this.stepType = stepType;
        }

        /// <summary>
        /// Obtient le nom de l'étape
        /// </summary>
        public string Name
        {
            get
            {
                return stepType.GetName();
            }
        }

        /// <summary>
        /// Obtient la description de l'étape
        /// </summary>
        public string Description
        {
            get
            {
                return stepType.GetDescription();
            }
        }
    }
}
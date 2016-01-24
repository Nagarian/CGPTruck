using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace CGPTruck.WebAPI.Utils
{
    internal class FormUrlEncodedConfigAttribute : Attribute, IControllerConfiguration
    {
        public void Initialize(HttpControllerSettings controllerSettings, HttpControllerDescriptor controllerDescriptor)
        {
            //controllerSettings.Formatters.JsonFormatter.UseDataContractJsonSerializer
            controllerSettings.Formatters.Add(new JQueryMvcFormUrlEncodedFormatter());
        }
    }
}
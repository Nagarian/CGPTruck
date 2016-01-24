using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Utils
{
    internal static class Extensions
    {
        public static dynamic RemoveProperty<T>(this T fixMe, params string[] properties)
        {
            var t = fixMe.GetType();
            var returnClass = new System.Dynamic.ExpandoObject() as IDictionary<string, object>;

            foreach (var pr in t.GetProperties())
            {
                if (properties.Contains(pr.Name))
                {
                    continue;
                }

                var val = pr.GetValue(fixMe);
                var subTypes = properties.Where(s => s.StartsWith(pr.Name)).Select(s => s.Substring(s.IndexOf('.') + 1)).ToArray();

                if (subTypes.Length != 0 && val != null)
                {
                    returnClass.Add(pr.Name, val.RemoveProperty(subTypes));
                    continue;
                }

                returnClass.Add(pr.Name, val);
            }

            return returnClass;
        }
    }
}
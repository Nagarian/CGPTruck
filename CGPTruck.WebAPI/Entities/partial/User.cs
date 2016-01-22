using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    public partial class User
    {
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
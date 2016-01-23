using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CGPTruck.WebAPI.Controllers
{
    [Authorize]
    public class BaseController : ApiController
    {
        private User currentUser;

        public User CurrentUser
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                {
                    return null;
                }

                if (currentUser == null)
                {
                    using (CGPTruckEntities context = new CGPTruckEntities())
                    {
                        var aspId = User.Identity.GetUserId();
                        
                        currentUser = (from user in context.Users.Include(u => u.Phones)
                                       where user.AspNetId == aspId
                                       select user).FirstOrDefault();
                    }
                }

                return currentUser;
            }
        }
    }
}

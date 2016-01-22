using CGPTruck.BLL;
using CGPTruck.WebAPI.Entities.Entities;
using CGPTruck.WebAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CGPTruck.WebAPI.Controllers
{
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IdentityResult result = await _repo.RegisterUser(userModel.UserName, userModel.Password);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                var aspUser = await _repo.FindUser(userModel.UserName, userModel.Password);
                using (CGPTruckEntities context = new CGPTruckEntities())
                {
                    context.Users.Add(new Entities.User
                    {
                        AspNetId = aspUser.Id,
                        AccountType = userModel.AccountType,
                        DriverLicenseType = userModel.DriverLicenseType,
                        Birthday = userModel.BirthdayDate,
                        FirstName = userModel.FirstName,
                        LastName = userModel.LastName,
                        Sexe = userModel.Sexe,
                        Active = true,
                    });
                    context.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
using CGPTruck.WebAPI.BLL;
using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using CGPTruck.WebAPI.Models;
using CGPTruck.WebAPI.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace CGPTruck.WebAPI.Controllers
{
    /// <summary>
    /// Controller concernant l'authentification et les méthodes spécifiques à l'utilisateur
    /// </summary>
    [Authorize]
    [FormUrlEncodedConfig]
    public class AccountController : BaseController
    {
        // POST api/Account/Register
        /// <summary>
        /// Administrator : Permet de créer un nouveau compte utilisateur
        /// </summary>
        /// <param name="userModel">Information concernant le nouvel utilisateur</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Register(UserModel userModel)
        {
            if (CurrentUser.AccountType != AccountType.Administrator)
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                using (AuthRepository authContext = new AuthRepository())
                {
                    IdentityResult result = await authContext.RegisterUser(userModel.UserName, userModel.Password);

                    IHttpActionResult errorResult = GetErrorResult(result);

                    if (errorResult != null)
                    {
                        return errorResult;
                    }

                    var aspUser = await authContext.FindUser(userModel.UserName, userModel.Password);
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

            }
            catch (Exception)
            {
                throw;
            }

            return Ok();
        }

        /// <summary>
        /// Permet d'obtenir un token d'authentification OAuth2 pour l'API
        /// </summary>
        /// <returns>Token OAuth2</returns>
        [Route("token")]
        [ResponseType(typeof(Token))]
        public IHttpActionResult FakeLoginForApiHelpPage([FromBody] Credentials credentials)
        {
            return InternalServerError();
        }

        // GET api/Account/Me
        /// <summary>
        /// Permet de récupérer ses propres informations
        /// </summary>
        /// <returns>Information concernant l'utilisateur</returns>
        [ResponseType(typeof(User))]
        [HttpGet]
        public IHttpActionResult Me()
        {
            var user = BLLUsers.Current.GetUserInformations(CurrentUser.Id);

            //var jsonResolver = new Utils.IgnorableSerializerContractResolver();
            //jsonResolver.Ignore<User>(u => u.AspNetId)
            //            .Ignore<User>(u => u.Id)
            //            .Ignore<User>(u => u.Phones);
            //var jsonSettings = new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, ContractResolver = jsonResolver };
            //return Ok(JsonConvert.DeserializeObject(JsonConvert.SerializeObject(user, jsonSettings)));
            
            return Ok(user.RemoveProperty("AspNetId", "Id", "Phones", "RealPhone.Users"));
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

        #region FakeLogin Class
        /// <summary>
        /// Credentials pour s'authentifier
        /// </summary>
        public class Credentials
        {
            /// <summary>
            /// Type de Token à récupéré, spécifié "password"
            /// </summary>
            public string grant_type { get; set; }

            /// <summary>
            /// Nom d'utilisateur
            /// </summary>
            public string username { get; set; }

            /// <summary>
            /// Mot de passe de l'utilisateur
            /// </summary>
            public string password { get; set; }
        }

        /// <summary>
        /// Token OAuth2 de réponse
        /// </summary>
        public class Token
        {
            /// <summary>
            /// Token a utilisé
            /// </summary>
            public string access_token { get; set; }

            /// <summary>
            /// Type du token
            /// </summary>
            public string token_type { get; set; }

            /// <summary>
            /// Temps avant son expiration (en secondes)
            /// </summary>
            public int expires_in { get; set; }
        } 
        #endregion
    }
}
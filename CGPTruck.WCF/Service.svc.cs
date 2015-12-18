using CGPTruck.BLL;
using CGPTruck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CGPTruck.WCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service : IService
    {
        private Users usersMethods;

        public Service()
        {
            usersMethods = new Users();
        }

        public string AuthenticateUser(string email, string password)
        {
            User user = usersMethods.AuthenticateUser(email, password);

            if (user == null)
            {
                return null;
            }

            return usersMethods.GenerateTokenForUser(user.Id);
        }
    }
}

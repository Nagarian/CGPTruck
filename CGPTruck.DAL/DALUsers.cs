using CGPTruck.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.DAL
{
    public class DALUsers
    {
        public User GetUserByToken(string token)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                User currentUser = (from user in context.Users.Include("Credential")
                                    where user.Credential.Token == token
                                    select user).FirstOrDefault();
                if (currentUser != null)
                {
                    currentUser.Credential = null;
                }

                return currentUser;
            }
        }

        public User GetUserByEmail(string email)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from user in context.Users.Include("Credential")
                        where user.Email == email
                        select user).FirstOrDefault();
            }
        }

        public void UpdateUserToken(int userId, string token)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var credential = (from cred in context.Credentials
                                  where cred.UserId == userId
                                  select cred).FirstOrDefault();

                credential.Token = token;
                context.SaveChanges();
            }
        }
    }
}

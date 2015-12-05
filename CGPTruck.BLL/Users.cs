using CGPTruck.DAL;
using CGPTruck.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.BLL
{
    public class Users
    {
        private DALUsers users;

        public Users()
        {
            users = new DALUsers();
        }

        public User AuthenticateUser(string email, string password)
        {
            User user = users.GetUserByEmail(email);
            
            if (user == null || user.Credential.Hash != ComputeHash(password, user.Credential.Salt))
            {
                return null;
            }

            return user;
        }

        public string GenerateTokenForUser(int userId)
        {
            string token = Guid.NewGuid().ToString();
            users.UpdateUserToken(userId, token);
            return token;
        }

        private string ComputeHash(string password, string salt)
        {
            return password + salt;
        }
    }
}

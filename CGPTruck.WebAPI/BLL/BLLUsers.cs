using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.BLL
{
    /// <summary>
    /// Business Logic Layer des users
    /// </summary>
    public class BLLUsers
    {
        /// <summary>
        /// Permet d'obtenir une instance rapidement
        /// </summary>
        public static BLLUsers Current { get; set; } = new BLLUsers();

        /// <summary>
        /// Permet d'obtenir les informations d'un utilisateur
        /// </summary>
        /// <param name="userId">Id de l'utilisateur</param>
        /// <returns>User avec son téléphone</returns>
        public User GetUserInformations(int userId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from user in context.Users.Include(u => u.Phones)
                        where user.Id == userId
                        select user).FirstOrDefault();
            }
        }

        /// <summary>
        /// Permet d'obtenir la liste des réparateurs
        /// </summary>
        /// <returns></returns>
        public List<User> GetRepairers()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from user in context.Users.Include(u => u.Phones)
                        where user.AccountType == AccountType.Repairer
                        select user).ToList();
            }
        }
    }
}
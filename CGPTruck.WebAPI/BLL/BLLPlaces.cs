using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.BLL
{
    /// <summary>
    /// Business Logic Layer des places
    /// </summary>
    public class BLLPlaces
    {
        /// <summary>
        /// Permet d'obtenir une instance rapidement
        /// </summary>
        public static BLLUsers Current { get; set; } = new BLLUsers();

        /// <summary>
        /// Permet d'obtenir toutes les places de la BDD
        /// </summary>
        /// <returns></returns>
        public Place GetPlaces()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from place in context.Places.Include(p => p.Position)
                        select place).SingleOrDefault();
            }
        }


        /// <summary>
        /// Permet d'obtenir les détails d'une place
        /// </summary>
        /// <param name="placeId">ID de la place</param>
        /// <returns></returns>
        public Place GetPlace(int placeId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from place in context.Places.Include(p => p.Position)
                        where place.Id == placeId
                        select place).SingleOrDefault();
            }
        }
    }
}
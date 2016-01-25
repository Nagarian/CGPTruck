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
    /// Business Logic Layer des pannes
    /// </summary>
    public class BLLFailures
    {
        /// <summary>
        /// Permet d'obtenir une instance rapidement
        /// </summary>
        public static BLLFailures Current { get; set; } = new BLLFailures();


        /// <summary>
        /// Permet d'obtenir toutes les pannes active de la BDD
        /// </summary>
        /// <returns></returns>
        public List<Failure> GetFailures()
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from failure in context.Failures.Include(f => f.Mission.Driver.Phones)
                                                        .Include(f => f.Vehicule)
                        where failure.State == FailureState.Declared
                        select failure).ToList();
            }
        }
    }
}
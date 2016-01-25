using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core;
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

        /// <summary>
        /// Permet d'assigner un réparateur à une panne
        /// </summary>
        /// <param name="failureId">ID de la panne</param>
        /// <param name="repairedId">ID du réparateur</param>
        public void AssignRepairerToFailure(int failureId, int repairedId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var f = (from failure in context.Failures
                         where failure.Id == failureId && failure.State != FailureState.Resolved
                         select failure).SingleOrDefault();
                if (f == null)
                {
                    throw new ObjectNotFoundException();
                }

                f.Repairer_Id = repairedId;
                f.State = FailureState.Processing;
                context.SaveChanges();
            }
        }
    }
}
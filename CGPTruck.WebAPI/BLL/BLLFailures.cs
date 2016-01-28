using CGPTruck.WebAPI.Entities;
using CGPTruck.WebAPI.Entities.Entities;
using CGPTruck.WebAPI.Models;
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
        /// Permet d'obtenir une panne
        /// </summary>
        /// <param name="failureId">ID de la panne a récupéré</param>
        /// <returns></returns>
        public Failure GetFailure(int failureId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from failure in context.Failures.Include(f => f.FailureDetail)
                                                        .Include(f => f.Mission.Steps)
                                                        .Include(f => f.Repairer)
                                                        .Include(f => f.RepairerVehicule)
                                                        .Include(f => f.Vehicule)
                        where failure.Id == failureId
                        select failure).SingleOrDefault();
            }
        }

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
        /// Permet d'obtenir toutes les pannes déclaré assigné à un réparateur
        /// </summary>
        /// <param name="repairerId">ID du réparateur</param>
        /// <returns></returns>
        public List<Failure> GetRepairerDeclaredFailures(int repairerId)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                return (from failure in context.Failures.Include(f => f.Mission.Driver.Phones)
                                                        .Include(f => f.Vehicule)
                        where failure.State != FailureState.Resolved && failure.Repairer_Id == repairerId
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

        /// <summary>
        /// Ajoute une panne
        /// </summary>
        /// <param name="failure"></param>
        public void AddFailure(Failure failure)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                context.Failures.Add(failure);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Met à jour une panne
        /// </summary>
        /// <param name="failureId">ID de la panne</param>
        /// <param name="failure">Détail de la panne</param>
        public void UpdateFailure(int failureId, FailureModel failure)
        {
            using (CGPTruckEntities context = new CGPTruckEntities())
            {
                var fail = (from fa in context.Failures.Include(f => f.FailureDetail)
                                                        .Include(f => f.Mission.Steps)
                                                        .Include(f => f.Repairer)
                                                        .Include(f => f.RepairerVehicule)
                                                        .Include(f => f.Vehicule.Position)
                            where fa.Id == failureId
                            select fa).SingleOrDefault();
                if (fail == null)
                {
                    return;
                }

                fail.State = failure.State;
                if (fail.FailureDetail == null)
                {
                    fail.FailureDetail = failure.FailureDetail;
                }
                else
                {
                    fail.FailureDetail.Attachments = failure.FailureDetail.Attachments;
                    fail.FailureDetail.Description = failure.FailureDetail.Description;
                    fail.FailureDetail.Write_Date = fail.FailureDetail.Write_Date;
                }

                if (failure.State == FailureState.Resolved)
                {
                    fail.Mission.Steps.Add(new Step
                    {
                        Date = DateTime.Now,
                        Informations = "RAS",
                        Position = new Position
                        {
                            Latitude = fail.Mission.Vehicule.Position.Latitude,
                            Longitude = fail.Mission.Vehicule.Position.Longitude
                        },
                        StepNumber = fail.Mission.Steps.Max(s => s.StepNumber) + 1,
                        Step_Type = StepType.DisasterRecovery
                    });
                    fail.Mission.Steps.Add(new Step
                    {
                        Date = DateTime.Now,
                        Informations = "RAS",
                        Position = new Position
                        {
                            Latitude = fail.Mission.Vehicule.Position.Latitude,
                            Longitude = fail.Mission.Vehicule.Position.Longitude
                        },
                        StepNumber = fail.Mission.Steps.Max(s => s.StepNumber) + 1,
                        Step_Type = StepType.DeliveryProgressing
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
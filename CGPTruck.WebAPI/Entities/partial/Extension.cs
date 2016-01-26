using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGPTruck.WebAPI.Entities
{
    /// <summary>
    /// Méthode d'extension du StepType
    /// </summary>
    public static class Extension
    {
        /// <summary>
        /// Permet d'obtenir l'intitulé (en Fr) de l'enumération
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string GetName(this StepType step)
        {
            switch (step)
            {
                case StepType.Waiting:
                    return "En attente de démarrage";
                case StepType.PickupProgressing:
                    return "Vers lieu d'enlèvement";
                case StepType.PickingUp:
                    return "Enlèvement";
                case StepType.DeliveryProgressing:
                    return "Vers livraison";
                case StepType.Delivering:
                    return "Livraison";
                case StepType.Returning:
                    return "Retour au garage";
                case StepType.Finished:
                    return "Terminée";
                case StepType.Failure:
                    return "Panne";
                case StepType.DisasterRecovery:
                    return "Reprise d'activité";
                case StepType.Aborted:
                    return "Avortée";
                default:
                    return string.Empty;
            }
        }

        public static string GetDescription(this StepType step)
        {
            switch (step)
            {
                case StepType.Waiting:
                    return "Une mission a été initialisée par un administrateur. Cette dernière commencera lorsque l'utilisateur concernée aura récupérer les informations associées sur son téléphone.";
                case StepType.PickupProgressing:
                    return "Le camion se dirige actuellement vers le lieu où il pourra récupérer la cargaison.";
                case StepType.PickingUp:
                    return "La cargaison est actuellement en cours de chargement dans le camion.";
                case StepType.DeliveryProgressing:
                    return "Le camion se dirige actuellement vers le lieu de livraison de la cargaison.";
                case StepType.Delivering:
                    return "La cargaison est actuellement en cours de déchargement au point de livraison.";
                case StepType.Returning:
                    return "Le camion est actuellement en train de retourner au garage.";
                case StepType.Finished:
                    return "La mission s'est terminée avec succès.";
                case StepType.Failure:
                    return "Le camion a rencontré une panne au cours de la mission.";
                case StepType.DisasterRecovery:
                    return "La panne du camion a été corrigée. Le camion reprend la mission a l'étape précédent la panne.";
                case StepType.Aborted:
                    return "La mission s'est terminée sans avoir été menée à bien.";
                default:
                    return string.Empty;
            }
        }
    }
}
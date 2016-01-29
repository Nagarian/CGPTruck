using CGPTruck.UWP.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.UWP.Core
{
    class Settings
    {
        private static Settings instance = null;
        private static readonly object myLock = new object(); // Pour éviter, lors de l’utilisation de multiple thread, que plusieurs singleton soit instanciés.

        public Mission actualMission { get; set; }
        public Failure actualFailure { get; set; }

        private Settings() { }

        public static Settings getInstance()
        {
            //lock permet de s’assurer qu’un thread n’entre pas dans une section critique du code pendant qu’un autre thread s’y trouve. 
            //Si un autre thread tente d’entrer dans un code verrouillé, il attendra, bloquera, jusqu’à ce que l’objet soit libéré.
            lock (myLock)
            {
                if (instance == null) instance = new Settings();
                return instance;
            }
        }

        public bool isDriver { get; set; } = true;

    }
}

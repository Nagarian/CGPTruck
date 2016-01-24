using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CGPTruck.WebAPI.BLL;

namespace CGPTruck.Test
{
    [TestClass]
    public class BLLMissionsTest
    {
        private BLLMissions missions;

        public BLLMissionsTest()
        {
             missions = new BLLMissions();
        }

        [TestMethod]
        public void TestGetMissions()
        {
            var m = missions.GetMissions();

        }


        [TestMethod]
        public void TestGetActiveMissions()
        {
            var m = missions.GetActiveMissions();

        }
    }
}

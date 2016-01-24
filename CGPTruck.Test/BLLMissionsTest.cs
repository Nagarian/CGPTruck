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

        [TestMethod]
        public void TestGetMissionSteps()
        {
            var m = missions.GetMissionSteps(1);
            var m2 = missions.GetMissionSteps(2);
        }


        [TestMethod]
        public void TestGetMission()
        {
            var m = missions.GetMission(1);
            var m2 = missions.GetMissionFullDetail(2);
        }
    }
}

using CGPTruck.WebAPI.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGPTruck.Test
{
    [TestClass]
    public class BLLVehiculesTest
    {
        private BLLVehicules vehicules;

        public BLLVehiculesTest()
        {
            vehicules = new BLLVehicules();
        }

        [TestMethod]
        public void TestGetVehicules()
        {
            var v = vehicules.GetVehicules();
        }
    }
}

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
    public class BLLFailuresTest
    {
        [TestMethod]
        public void TestUpdateFailure()
        {
            BLLFailures.Current.UpdateFailure(1, new WebAPI.Models.FailureModel
            {
                State = WebAPI.Entities.FailureState.Resolved,
                FailureDetail = new WebAPI.Entities.FailureDetail
                {
                    Description = "cool"
                }
            });
        }
    }
}

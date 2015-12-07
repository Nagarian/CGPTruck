using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CGPTruck.DAL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CGPTruck.DAL.DALUsers users = new DALUsers();
            var user = users.GetUserByEmail("jean-michel@gros-lourd.fr");
            Assert.IsNotNull(user);
        }
    }
}

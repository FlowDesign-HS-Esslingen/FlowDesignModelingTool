using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowDesign.DataAccess;

namespace FlowDesign.Test.DataAccessTest
{
    [TestClass]
    public class DataAccessProviderTest
    {
        [TestMethod]
        public void CreateLocalAccess_Test()
        {
            IRepository testRepository = DataAccessProvider.GetRepository(DataAccessType.Local);

            Assert.IsInstanceOfType(testRepository, typeof(IRepository));
        }
    }
}

using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeaStall.ApplicationBuilder;
using TeaStall.Business.Models;

namespace TeaStall.Business.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ContainerManager.BuildContainer();
            var business = ContainerManager.Current.Resolve<ITeaStallBusiness>();

            Assert.IsNotNull(business);
        }
    }
}

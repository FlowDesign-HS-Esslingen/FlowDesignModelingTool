using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowDesign.Model;

namespace FlowDesign.Test.ModelTest
{
    // @TODO: Diagram liegt OnHold!
    [TestClass]
    public class DiagramTest
    {
        Diagram flowViewDiagram;
        Diagram systemEnvDiagram;
        Diagram prototypeDiagram;

        [TestInitialize]
        public void DiagramTestInitialize()
        {
            flowViewDiagram = new Model.Flow.FlowViewDiagram();
            systemEnvDiagram = new Model.Flow.SystemEnvDiagram();
            prototypeDiagram = new Model.Flow.PrototypeDiagram();
        }


        [TestMethod]
        public void ToString_Test()
        {
            Console.WriteLine("FLOW:"); Console.WriteLine(flowViewDiagram.ToString());
            Console.WriteLine("SYSTEM:"); Console.WriteLine(systemEnvDiagram.ToString());
            Console.WriteLine("PROTOTYPE:"); Console.WriteLine(prototypeDiagram.ToString());

            Assert.IsNotNull(flowViewDiagram.ToString());
            Assert.IsNotNull(systemEnvDiagram.ToString());
            Assert.IsNotNull(prototypeDiagram.ToString());
        }

        [TestMethod]
        public void Type_Test()
        {
            Assert.IsInstanceOfType(flowViewDiagram, typeof(Diagram));
            Assert.IsInstanceOfType(systemEnvDiagram, typeof(Diagram));
            Assert.IsInstanceOfType(prototypeDiagram, typeof(Diagram));
            Assert.IsInstanceOfType(flowViewDiagram, typeof(Model.Flow.FlowViewDiagram));
            Assert.IsInstanceOfType(systemEnvDiagram, typeof(Model.Flow.SystemEnvDiagram));
            Assert.IsInstanceOfType(prototypeDiagram, typeof(Model.Flow.PrototypeDiagram));
        }


        [TestCleanup]
        public void DiagramTestCleanup()
        {
            flowViewDiagram = null;
            systemEnvDiagram = null;
            prototypeDiagram = null;
        }
    }

}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowDesign.Model;
using System.Collections.Generic;

namespace FlowDesign.Test.ModelTest
{
    [TestClass]
    public class ProjectTest
    {
        Project testProject;
        ProjectInfo testInfo;
        List<Diagram> testDiagrams;

        [TestInitialize]
        public void ProjectTestInitialize()
        {
            testProject = new Project();
            testInfo = testProject.Info;
            testDiagrams = testProject.Diagrams;
        }

        [TestMethod]
        public void ProjectInfo_Test()
        {
            // Test ob alle Attribute gesetzt wurden.
            Console.WriteLine("Test Info:");
            Console.WriteLine("Name: " + testInfo.Name);
            Console.WriteLine("CreationDate: " + testInfo.CreationDate);
            Console.WriteLine("ModifiedDate: " + testInfo.ModifiedDate);
            Console.WriteLine("Filepath: " + testInfo.Filepath);

            Assert.IsNotNull(testInfo);
            Assert.IsNotNull(testInfo.Name);
            Assert.IsNotNull(testInfo.CreationDate);
            Assert.IsNotNull(testInfo.ModifiedDate);
            Assert.IsNotNull(testInfo.Filepath);
        }

        [TestMethod]
        public void ProjectDiagrams_test()
        {
            // Test ob eine Liste erstellt wurde.
            Console.WriteLine("Test Diagrams:");
            Console.WriteLine(testDiagrams.ToString());

            Assert.IsNotNull(testDiagrams);
            CollectionAssert.AllItemsAreInstancesOfType(testDiagrams, typeof(Diagram));
        }


        [TestCleanup]
        public void ProjectTestCleanup()
        {
            testProject = null;
            testInfo = null;
            testDiagrams = null;
        }
    }

}

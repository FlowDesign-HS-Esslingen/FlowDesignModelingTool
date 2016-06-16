using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowDesign.DataAccess;
using FlowDesign.Model;
using FlowDesign.Service;
using FlowDesign.Service.Diagrams;
using FlowDesign.Model.Flow;
using FlowDesign.Service.Diagrams.Flow;

namespace FlowDesign.Test.DataAccessTest
{
    [TestClass]
    public class LocalRepositoryTest
    {
        IRepository testLocalRepository;
        Project testProject;

        [TestInitialize]
        public void LocalRepositoryTestIntialize()
        {
            testLocalRepository = DataAccessProvider.GetRepository(DataAccessType.Local);
        }

        [TestMethod]
        public void LoadProject_Test_Null()
        {
            testProject = testLocalRepository.LoadProject(null);
            Assert.IsNull(testProject);
        }

        [TestMethod]
        public void SaveProject_Test_Null()
        {
            testLocalRepository.SaveProject(null);
        }

        [TestMethod]
        public void SaveAndLoadProject_Test()
        {
            Project newProject = new Project();
            testProject = new Project();
            testProject.Info.Name = "TestProjekt";
            testProject.Info.Filepath = "C:\\flowtest/test";
            testLocalRepository.SaveProject(testProject);

            newProject = testLocalRepository.LoadProject(testProject.Info.Filepath + "\\ProjectInfo.flow");

            Console.WriteLine("Project before Saving:");
            Console.WriteLine("Name: " + testProject.Info.Name);
            Console.WriteLine("Filepath: " + testProject.Info.Filepath);
            Console.WriteLine("CreationDate: " + testProject.Info.CreationDate);
            Console.WriteLine("ModifiedDate: " + testProject.Info.ModifiedDate + System.Environment.NewLine);
            Console.WriteLine("Loaded Project: ");
            Console.WriteLine("Name: " + newProject.Info.Name);
            Console.WriteLine("Filepath: " + newProject.Info.Filepath);
            Console.WriteLine("CreationDate: " + newProject.Info.CreationDate);
            Console.WriteLine("ModifiedDate: " + newProject.Info.ModifiedDate);

            // @TODO: wie genau ist das richtig?
            //Assert.AreEqual(testProject, newProject);
            // Assert.AreSame(newProject, testProject);
            Assert.ReferenceEquals(newProject, testProject);
        }

        [TestMethod]
        public void SaveAndLoadConfig_Test()
        {
            // @TODO
            ApplicationConfig testConfig = new ApplicationConfig();
        }


        [TestMethod]
        public void SaveDiagramProject_Test() //nur zum Testen (Daniel G.)
        {
            testProject = new Project();
            testProject.Info.Name = "TestProjekt";
            testProject.Info.Filepath = "C:/TestProjekt";
            DiagramFactory testFactory = new DiagramFactory();

            IDiagramStrategy diagram = new SystemEnvDiagramFactory();
            testFactory.Register(typeof(SystemEnvDiagram), diagram);

            testProject.Diagrams.Add(testFactory.CreateDiagram<SystemEnvDiagram>("SystemEnvDiagram"));

            testLocalRepository.SaveProject(testProject);
        }

        [TestMethod]
        public void LoadDiagramProject_Test() //nur zum Testen (Daniel G.)
        {
            testLocalRepository.LoadProject("C:/TestProjekt/ProjectInfo.flow");

        }

    }

}

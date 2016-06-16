using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlowDesign.DataAccess;
using FlowDesign.Model;

namespace FlowDesign.Test.DataAccessTest
{
    [TestClass]
    public class XmlConverterTest
    {
        DataAccess.Converter.XmlConverter testConverter;
        Project testProject1;
        Project testProject2;
        String testXML;

        [TestInitialize]
        public void XmlConverterTestIlitialize()
        {
            testConverter = new DataAccess.Converter.XmlConverter();
            testProject1 = new Project();
            testProject1.Info.Name = "Dies ist ein Test Projekt";
            testProject1.Info.Filepath = "C:\\flowtest/test";
            testXML = @"<?xml version=""1.0"" encoding=""utf-8""?><Project xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema""><Info><Name>Dies war eine XML Datei</Name><ModifiedDate>2016-05-14T23:48:21.898274+02:00</ModifiedDate><Filepath>C:\flowtest/test</Filepath></Info><Diagrams /></Project>";
        }

        [TestMethod]
        public void ConvertObject_Test()
        {
            String output = testConverter.ConvertObject(testProject1);

            Console.WriteLine(output);
            Assert.IsNotNull(output);
        }

        [TestMethod]
        public void ConvertObjectBack_Test()
        {
            testProject2 = testConverter.ConvertObjectBack<Project>(testXML);

            Console.WriteLine(testProject2.ToString());
            Assert.AreEqual("Dies war eine XML Datei", testProject2.Info.Name);
        }

        [TestMethod]
        public void ConvertAndConvertBack_Test()
        {
            String XML = testConverter.ConvertObject(testProject1);
            testProject2 = testConverter.ConvertObjectBack<Project>(XML);

            // @TODO: Kann man auch das ganz Objekt überprüfen?
            Assert.AreEqual(testProject1.Info.Name, testProject2.Info.Name);
            // Assert.AreEqual<Project>(testProject1, testProject2);
        }


        [TestCleanup]
        public void XmlConverterCleanup()
        {
            testConverter = null;
            testProject1 = null;
            testProject2 = null;
        }
    }
}

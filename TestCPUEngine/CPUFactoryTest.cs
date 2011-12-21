using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU;

namespace TestCPUEngine
{   
    /// <summary>
    ///This is a test class for CPUFactoryTest and is intended
    ///to contain all CPUFactoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CPUFactoryTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        /// Test GetCPU "Easy"
        ///</summary>
        [TestMethod()]
        public void GetCPUTestEasy()
        {
            string cpuName = CPUFactory.CPU_EASY;
            ICPU actual= CPUFactory.GetCPU(cpuName);
            Assert.IsTrue( actual is CPU, "wrong class. Expect CPU");
        }


        /// <summary>
        /// Test GetCPU "Mock"
        ///</summary>
        [TestMethod()]
        public void GetCPUTestMock()
        {
            string cpuName = CPUFactory.CPU_MOCK;
            ICPU actual= CPUFactory.GetCPU(cpuName);
            Assert.IsTrue(actual is CPUMock, "wrong class. Expect CPUMock");
        }
    }
}

using ch.zhaw.HenselerGroup.CPU;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace TestCPUEngine
{  
    
    /// <summary>
    ///This is a test class for CPUTest and is intended
    ///to contain all CPUTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CPUTest
    {
        IMemory mem = null;
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
         
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            
        }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            mem = new MemoryBasic();
            mem.Init(Config.MEM_SIZE); 
        }
        //
        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            mem = null;
        }
        
        #endregion


        /// <summary>
        ///A test for LoadMemory
        ///</summary>
        [TestMethod()]
        public void LoadMemoryTest()
        {
            
            CPU target = new CPU(); // TODO: Initialize to an appropriate value
            string[] codelines = new string[] {
                "ADD R1",
                "ADD 500",
                "ADD R2"
            };
            int startAddress = 0; // TODO: Initialize to an appropriate value
            target.LoadMemory(codelines, startAddress);

            Assert.AreEqual(0,mem.GetWord(0).UValue);
            Assert.AreEqual(0, mem.GetWord(1).UValue);
            Assert.AreEqual(0, mem.GetWord(2).UValue);

           
        }
    }
}

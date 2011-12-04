using ch.zhaw.HenselerGroup.CPU;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

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
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
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
            CPU target = new CPU();

            string[] codelines = new string[] {
                "ADD R1",
                "ADD 500",
                "ADD R2"
            };
            int startAddress = 0; // TODO: Initialize to an appropriate value
            target.LoadMemory(codelines, startAddress);

            Assert.AreNotEqual(0, target.Memory.GetWord(0).UValue);  // ADD R1
            Assert.AreNotEqual(0, target.Memory.GetWord(2).UValue);  // ADD 500
            Assert.AreNotEqual(0, target.Memory.GetWord(4).UValue);  // ADD R2
            Assert.AreEqual(0, target.Memory.GetWord(6).UValue);
        }

        /// <summary>
        /// Test FileNotFoundException
        ///</summary>
        [TestMethod()]
        public void ReadPgmTestFileNotFound()
        {
            CPU target = new CPU();
            string fullFilename = "FileNotExist.cpu";
            string[] actual;
            try
            {
                actual = target.ReadPgm(fullFilename);
                Assert.Fail("fileNotFoundException exptected");
            }
            catch (FileNotFoundException)
            {
                Assert.IsTrue(true);
            }
        }

        /// <summary>
        /// Test Extention not Supported
        ///</summary>
        [TestMethod()]
        public void ReadPgmTestFileExtNotSupported()
        {
            CPU target = new CPU();
            string fullFilename = "FileNotExist.txt";
            string[] actual;
            try
            {
                actual = target.ReadPgm(fullFilename);
                Assert.Fail("FileExtention not supported");
            }
            catch (CPUException)
            {
                Assert.IsTrue(true);
            }
        }



        /// <summary>
        ///A test for LoadMemory
        ///</summary>
        [TestMethod()]
        public void AddNegNumTest()
        {
            CPU target = new CPU();

            string[] codelines = new string[] {
                "LOAD R0,-500",
                "ADD 250"
            };
            int startAddress = 0; 
            target.LoadMemory(codelines, startAddress);

            Assert.AreNotEqual(0, target.Memory.GetWord(0).UValue);
            Assert.AreNotEqual(0, target.Memory.GetWord(2).UValue);
            Assert.AreEqual(0, target.Memory.GetWord(4).UValue); 

            target.Run(startAddress);
            Assert.AreEqual(-250, target.GetRegisterValue(0));
        }


    }
}

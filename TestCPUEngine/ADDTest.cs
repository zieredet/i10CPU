using ch.zhaw.HenselerGroup.CPU.Impl.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;
using ch.zhaw.HenselerGroup.CPU;

namespace TestCPUEngine
{   
    /// <summary>
    ///This is a test class for ADDTest and is intended
    ///to contain all ADDTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ADDTest
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
        public void MyTestInitialize()
        {
            CPU cpu = new CPU();
        }
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Test Decode ADD 35
        ///</summary>
        [TestMethod()]
        public void DecodeTestAdd35()
        {
            ADD target= new ADD();
            target.Parse("ADD 35");
            Instruction expected = new Instruction(8262);
            Instruction actual;
            actual = target.Decode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test Decode ADD 4095
        ///</summary>
        [TestMethod()]
        public void DecodeTestAdd4095()
        {           
            ADD target = new ADD();
            target.Parse("ADD 4095");
            Instruction expected = new Instruction(16382);
            Instruction actual= target.Decode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Test Decode ADD -4095
        ///</summary>
        [TestMethod()]
        public void DecodeTestAddMin4095()
        {
            ADD target = new ADD();
            target.Parse("ADD -4095");
            Instruction expected = new Instruction(16383);
            Instruction actual = target.Decode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for Decode ADD R1
        ///</summary>
        [TestMethod()]
        public void DecodeTestAddR1()
        {
            ADD target = new ADD();
            target.Parse("ADD R1");
            Instruction expected = new Instruction(3840);
            Instruction actual = target.Decode();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Decode ADD R2
        ///</summary>
        [TestMethod()]
        public void DecodeTestAddR2()
        {
            ADD target = new ADD();
            target.Parse("ADD R2");
            Instruction expected = new Instruction(5888);
            Instruction actual = target.Decode();
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Test for Decode ADD R3
        ///</summary>
        [TestMethod()]
        public void DecodeTestAddR3()
        {
            ADD target = new ADD();
            target.Parse("ADD R3");
            Instruction expected = new Instruction(7936);
            Instruction actual = target.Decode();
            Assert.AreEqual(expected, actual);
        }
  

    }
}

using ch.zhaw.HenselerGroup.CPU.Impl.Memory;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace TestCPUEngine
{
    
    
    /// <summary>
    ///This is a test class for MemoryBasicTest and is intended
    ///to contain all MemoryBasicTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MemoryBasicTest
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
        ///A test for SetWord
        ///</summary>
        [TestMethod()]
        public void SetWordTest()
        {
            MemoryBasic target = new MemoryBasic(); // TODO: Initialize to an appropriate value
            int address = 0; // TODO: Initialize to an appropriate value
            Word word = null; // TODO: Initialize to an appropriate value
            target.SetWord(address, word);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetWord
        ///</summary>
        [TestMethod()]
        public void GetWordTest()
        {
            
            MemoryBasic mem = new MemoryBasic();
            mem.Init(10);
            int address = 4;
            Word expected = new Word(100);
            Word actual;
            mem.SetWord(address, expected);
            actual = mem.GetWord(address);
            Assert.AreEqual(expected, actual);
        }
    }
}

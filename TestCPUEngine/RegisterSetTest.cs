using ch.zhaw.HenselerGroup.CPU;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestCPUEngine
{
    /// <summary>
    ///This is a test class for RegisterSetTest and is intended
    ///to contain all RegisterSetTest Unit Tests
    ///</summary>
    [TestClass()]
    public class RegisterSetTest
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
        /// Test for all Set/GetRegisterVal 
        ///</summary>
        [TestMethod()]
        public void GetRegisterVal500Test()
        {
            RegisterSet target = new RegisterSet();

            for (int registerNr = 0; registerNr < RegisterSet.LastRegisterNr; registerNr++)
            {
                target.SetRegisterVal(registerNr, 500);
                int expected = 500;
                int actual = target.GetRegisterVal(registerNr);
                Assert.AreEqual(expected, actual);
            }
        }

        /// <summary>
        /// Test for all Set/GetRegisterVal 
        ///</summary>
        [TestMethod()]
        public void GetRegisterValMin500Test()
        {
            RegisterSet target = new RegisterSet();

            for (int registerNr = 0; registerNr < RegisterSet.LastRegisterNr; registerNr++)
            {
                target.SetRegisterVal(registerNr, -500);
                int expected = -500;
                int actual = target.GetRegisterVal(registerNr);
                Assert.AreEqual(expected, actual);
            }
        }


        /// <summary>
        /// Test for ACCU Set/GetRegisterVal 
        ///</summary>
        [TestMethod()]
        public void GetRegisterValAccuTest()
        {
            RegisterSet target = new RegisterSet();
            int[] testValues = { 0, -8500, 8500, 7000, 2, -66000, 65535, -65534, 900000 };

            foreach (int expected in testValues)
            {
                target.Accu = expected;
                int actual = target.Accu;
                Assert.AreEqual(expected, actual);
            }
        }
    }
}

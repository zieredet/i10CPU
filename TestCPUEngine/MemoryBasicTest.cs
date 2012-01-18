using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;
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
        public void SetWordMockTest()
        {

            MockRepository mocks = new MockRepository();

            var wordMock = MockRepository.GenerateStub<IWord>();  
            
            wordMock.Stub(x => x.UValue).Return(10);

        
            MemoryBasic target = new MemoryBasic();
            target.Init(16);

            int address = 8;

            target.SetWord(address, wordMock);

            IWord current = target.GetWord(address);
            
            Assert.AreEqual(current.UValue, wordMock.UValue);
        }

        /// <summary>
        ///A test for GetWord
        ///</summary>
        [TestMethod()]
        public void GetWordTest()
        {

            MockRepository mocks = new MockRepository();

            var wordMock = MockRepository.GenerateStub<IWord>();

            wordMock.Stub(x => x.UValue).Return(10);

            MemoryBasic target = new MemoryBasic();          
            
            target.Init(16);

            int address = 4;
                    
            target.SetWord(address, wordMock);
            
            IWord current = target.GetWord(address);

            Assert.AreEqual(wordMock.UValue, current.UValue);
        }


        /// <summary>
        ///A test for GetWordEnumerator
        ///</summary>
        [TestMethod()]
        public void GetWordEnumeratorTest()
        {
            IMemory target = new MemoryBasic();
            target.Init(10);

            IEnumerator<Word> actual = target.GetEnumerator();
            int i = 0;

            Word w = null;
            actual.Reset();
            while (actual.MoveNext())
            {
                w = actual.Current;
                i++;
            }
            
            Assert.AreEqual(5,i);
        }
    }
}

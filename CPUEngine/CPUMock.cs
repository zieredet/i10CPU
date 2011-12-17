using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;
using ch.zhaw.HenselerGroup.CPU.Impl.Commands;
using ch.zhaw.HenselerGroup.CPU.Impl;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class CPUMock : ICPU
    {
        private string[] codelines = new string[] { "ADD 250" };

        private IMemory mem = null;
        private RegisterSet registerSet = null;
        
        public CPUMock()
        {
            mem = new MemoryBasic();
            mem.Init(Config.MEM_SIZE);
            registerSet = new RegisterSet();
        }


        public string[] ReadPgm(string fullFilename)
        {
            return codelines;
        }

        public void LoadMemory(string[] codelines, int startAddress)
        {
            mem.SetInstruction(startAddress, 10000);
        }

        public void Run(int startAddress)
        {
            return;
        }

        public IMemory Memory
        {
            get { return mem; }
        }

        public int GetRegisterValue(int registerNr)
        {
            return 0;
        }

        public int GetRegisterUValue(int registerNr)
        {
            return -1;
        }
    }
}

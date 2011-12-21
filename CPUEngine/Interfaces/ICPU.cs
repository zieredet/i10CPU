using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    public interface ICPU
    {
        string[] ReadPgm(string fullFilename);
        void LoadMemory(string[] codelines, int startAddress);
        void Run(int startAddress);
        void RunStep(int startAddress);
        void RunFast(int startAddress);
        IMemory Memory { get; }
        int GetRegisterValue(int registerNr); int GetRegisterUValue(int registerNr);
    }
}

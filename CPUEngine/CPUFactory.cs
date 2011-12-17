using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class CPUFactory
    {
        public const string CPU_EASY = "EASY";
        public const string CPU_MOCK = "MOCK";

        public static ICPU GetCPU(string cpuName)
        {
            if (cpuName == CPU_EASY) return new CPU();
            if (cpuName == CPU_MOCK) return null;
            return null;
        }
    }
}

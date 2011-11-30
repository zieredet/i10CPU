using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class CPUException : Exception
    {
        public CPUException(string message) : base(message) { }
    }
}

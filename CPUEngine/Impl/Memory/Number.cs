using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    public class Number : Word
    {
        public bool Sign { get; set; }
        public int Value { get; set; }
    }
}

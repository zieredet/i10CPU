using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    public class Instruction : Word
    {
        public Instruction() : base() { }

        public Instruction(int value)
            : base(value)
        {
            // memValue = value;
        }

        public int InstructionCode
        {
            get { return memValue; }
            set { memValue = value; }
        }
    }
}

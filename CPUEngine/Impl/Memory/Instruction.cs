using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    public class Instruction : Word
    {
        private string opcode=null;
        public Instruction() : base() { }

        public Instruction(int value)
            : base(value)
        {
            // memValue = value;
        }

        public Instruction(int value, string opcode)
            : base(value)
        {
            this.opcode = opcode;
        }

        public int InstructionCode
        {
            get { return memValue; }
            set { memValue = value; }
        }

        public override bool Equals(object obj) { return base.Equals(obj); }
        public override int GetHashCode() { return base.GetHashCode(); }
        public override string ToString() { return String.Format("{0} ; {1}", memValue, opcode); }
    }
}

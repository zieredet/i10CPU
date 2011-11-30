using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Memory
{
    public class MemoryBasic : IMemory
    {
        private int[] mem = null;

        public void Init(int size)
        {
            mem = new int[size];
        }


        public Word GetWord(int address)
        {
            if (mem == null || mem.Length > address || address < 0) return null;
            return new Word( mem[address], mem[address+1]);
        }


        public void SetInstruction(int address, int instuction)
        {
            mem[address]= instuction;
        }


        public void SetInstruction(int address, Instruction instruction)
        {
            SetInstruction(address, instruction.InstructionCode);
        }

        public void SetWord(int address, Word word)
        {
            mem[address] = word.UValue;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class Memory : IMemory

    {

        private int size;
        private Word[] mem = null;

        public int Size
        {
            get { return size; ; }
        }

        public Memory(int size)
        {
            this.size = size;
            mem = new Word[size];
        }


        public Word GetWord(int address)
        {
            if (address < 0) return null;

            int adr = (address % 2 == 0 ? address / 2 : (address - 1) / 2);
            if (adr > Size) return null;
            return mem[adr];
        }

        public void SetInstruction(int address, Instruction instruction)
        {
            mem[address] = instruction;
        }
        public void SetNumber(int address, Number number)
        {
            mem[address] = number;
        }

        public void Init(int size)
        {
            throw new NotImplementedException();
        }

       
    }


    public abstract class Word
    {
        protected int memValue;
    }

    public class Instruction : Word
    {
        public int InstructionCode
        {
            get { return memValue; }
            set { memValue = value; }
        }
    }

    public class Number : Word
    {
        public bool Sign { get; set; }
        public int Value { get; set; }
    }
}

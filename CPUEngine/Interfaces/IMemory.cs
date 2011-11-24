﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    public interface IMemory
    {
        void Init(int size);

        Word GetWord(int address);
        void SetWord(int address, Word word);

        void SetInstruction(int address, int instuction);
        void SetInstruction(int address, Instruction instruction);
    }

    public class Word
    {
        protected int memValue;

        public Word() { }

        public Word(int memValue)
            : this()
        {
            this.memValue = memValue;
        }

        public int UValue { get { return memValue; } }

        public Word(int highByte, int lowByte)
            : this()
        {
            memValue = (highByte % 256) * 256 + (lowByte % 256);
        }


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
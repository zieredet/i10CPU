using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class RegisterSet
    {
        public const int LastRegisterNr = 4;  // 0=Accu, 1..4

        private int accuIdx { get { return LastRegisterNr + 1; } }
        private int[] registers = new int[LastRegisterNr + 1];


        public int Accu
        {
            get { return registers[accuIdx]; }
            set { registers[accuIdx] = value; }
        }

        public int R1
        {
            get { return registers[0]; }
            set { registers[0] = value; }
        }
        public int R2
        {
            get { return registers[1]; }
            set { registers[1] = value; }
        }
        public int R3
        {
            get { return registers[2]; }
            set { registers[2] = value; }
        }
        public int R4
        {
            get { return registers[3]; }
            set { registers[3] = value; }
        }

        public int GetRegisterVal(int registerNr)
        {
            return registers[registerNr];
        }
        public void SetRegisterVal(int registerNr, int value)
        {
            registers[registerNr] = value;
        }
    }
}


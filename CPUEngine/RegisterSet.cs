using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU
{
    public class RegisterSet
    {
        public const int LastRegisterNr = 3;  // 0=Accu, 1..3

        private int accuIdx { get { return LastRegisterNr + 1; } }
        private int[] registers = new int[LastRegisterNr + 2];

        protected int MemValToSignedInt(int uvalue)
        {
            if (uvalue % 2 == 1)
                return -(int)(uvalue / 2);
            else
                return uvalue / 2;
        }

        protected int SignedIntToMemVal(int value)
        {
            if (value < 0) return Math.Abs(value) * 2 + 1;
            return value * 2;
        }

        public int Accu
        {
            get { return GetRegisterVal(accuIdx); }
            set { SetRegisterVal(accuIdx, value); }
        }

        public int R1
        {
            get { return GetRegisterVal(0); }
            set { SetRegisterVal(0, value); }
        }
        public int R2
        {
            get { return GetRegisterVal(1); }
            set { SetRegisterVal(1, value); }
        }
        public int R3
        {
            get { return GetRegisterVal(2); }
            set { SetRegisterVal(2, value); }
        }
        public int R4
        {
            get { return GetRegisterVal(3); }
            set { SetRegisterVal(3, value); }
        }

        public int GetRegisterVal(int registerNr)
        {
            if (registerNr == 0)
                return MemValToSignedInt(registers[accuIdx]);
            else
                return MemValToSignedInt(registers[registerNr]);
        }
        public void SetRegisterVal(int registerNr, int value)
        {
            if (registerNr == 0)
                registers[accuIdx] = SignedIntToMemVal(value);
            else
                registers[registerNr] = SignedIntToMemVal(value);
        }

        
        public int GetRegisterUVal(int registerNr)
        {
            return registers[registerNr];
        }
    }
}


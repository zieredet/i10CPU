using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    public class ADD : ICommand
    {
        private int register = -1;
        private int absValue = 0;
        private bool useRegister = false;
        private bool errorWhileParsing = true;


        public void Execute(IMemory mem, RegisterSet registerSet)
        {
            if (errorWhileParsing) return;

            if (!useRegister)
            {
                registerSet.Accu += registerSet.GetRegisterVal(register);
                return;
            }

            registerSet.Accu += absValue;
            return;
        }

        public string Name
        {
            get { return "ADD"; }
        }


        public int CommandLength
        {
            get { return 2; }
        }

        /// <summary>
        /// ADD Rx   ; Add Register x to Accu
        /// ADD 500  ; Add 500 to Accu
        /// </summary>
        /// <param name="opcode"></param>
        /// <returns></returns>
        public void Parse(string opcode)
        {
            errorWhileParsing = true;
            useRegister = false;

            string[] parts = opcode.Split(' ');
            if (parts.Length != 2) return;

            string arg1 = parts[1].ToUpper();
            if (arg1.StartsWith("R"))
            {
                int.TryParse(arg1.Substring(1, 1), out register);    // according to MS, best bractice

                if (register < 1 || register > RegisterSet.LastRegisterNr) return;
                errorWhileParsing = false;
                useRegister = true;
                return;
            }

            int.TryParse(arg1, out absValue);
            errorWhileParsing = false;
            return;
        }


        public Instruction Decode()
        {
            if (errorWhileParsing) return new Instruction();  // Stop

            throw new NotImplementedException();
        }
    }
}

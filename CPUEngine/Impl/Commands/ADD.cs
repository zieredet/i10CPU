using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    /// <summary>
    /// ADD: add a number or register to Accu
    /// </summary>
    public class ADD : ICommand
    {
        private int register = -1;
        private int value = 0;
        private bool useRegister = false;
        private bool errorWhileParsing = true;
        private string orgCommand = null;
        
        public void Execute(IMemory mem, RegisterSet registerSet)
        {
            if (errorWhileParsing) return;

            if (!useRegister)
            {
                registerSet.Accu += registerSet.GetRegisterVal(register);
                return;
            }

            registerSet.Accu += value;
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
            orgCommand = opcode;

            int regNr = CommandBase.ParseRegister(opcode, 2);
            if( regNr != CommandBase.INVALID_VALUE_INT){
                // ADD Rx   ; Add Register x to Accu
                this.register = regNr;
                errorWhileParsing = false;
                useRegister = true;
                return;
            }

            int val=  CommandBase.ParseNumber(opcode, 2);
            errorWhileParsing = val == CommandBase.INVALID_VALUE_INT;
            this.value = val;
            return;
        }


        /// <summary>
        /// Checks if opcode represents this command
        /// </summary>
        /// <param name="word">A word from the memory</param>
        /// </param>
        /// <returns>true if the word represents this command</returns>
        public static bool CheckOpCode(Word word)
        {
            int result = word.UValue | 3072; 

            if (result == 3968)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Instruction Decode()
        {
            if (errorWhileParsing) return new Instruction(0);  // Stop

            // ADD Register 000xx111 <not used>
            // ADD #  0010<12Bit Data>
            if (useRegister)
            {
                int inst = 0 | 1024 | 512 | 256;

                if (useRegister) inst = inst | register * 2048;
                return new Instruction(inst);
            }

            int inst2 = 8192;
            inst2 += value;
            return new Instruction(inst2, orgCommand);

        }
        
        public string[] Syntax
        {
            get { return new string[] { 
                    "ADD Rx,value = Add value to Reg X",
                    "ADD value = Add value to Accu" 
                 }; 
            }
        }

        public string GetCommand()
        {
            return orgCommand;
        }
    }
}

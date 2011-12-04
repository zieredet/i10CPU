using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    public class LOAD : ICommand
    {
        private bool errorWhileParsing = true;
        private int value = 0;
        private int registerNr = 0;
        private string orgCommand = null;

        public void Execute(IMemory mem, RegisterSet registerSet)
        {
            if (errorWhileParsing) return;

            registerSet.SetRegisterVal(registerNr, value);
        }

        public string Name
        {
            get { return "LOAD"; }
        }

        public Instruction Decode()
        {
            if (errorWhileParsing) return new Instruction(0);  // Stop

            // LOAD Register 010xx<value>  
            int inst = 16387;  // 010....

            inst += registerNr * 2048;
            inst += value;

            return new Instruction(inst, orgCommand);
        }

        public int CommandLength
        {
            get { return 2; }
        }

        public void Parse(string opcode)
        {
            this.orgCommand = opcode;

            errorWhileParsing = true;
            int reg = CommandBase.ParseRegister(opcode, 2);
            int value = CommandBase.ParseNumber(opcode, 3);
            if (reg == CommandBase.INVALID_VALUE_INT || value == CommandBase.INVALID_VALUE_INT) return;

            registerNr = reg;
            this.value = value;
            errorWhileParsing = false;
        }


        public string[] Syntax
        {
            get { return new string[] { "LOAD Rx, value = Load value to Reg X" }; }
        }
        

        public string GetCommand() { return orgCommand; }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    public class MOVE : ICommand
    {
        private string orgCommand = null;

        public void Execute(IMemory mem, RegisterSet registerSet)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public Instruction Decode()
        {
            throw new NotImplementedException();
        }

        public int CommandLength
        {
            get { throw new NotImplementedException(); }
        }

        public ICommand Parse(string opcode)
        {
            orgCommand = opcode;

            throw new NotImplementedException();
        }

        void ICommand.Parse(string opcode)
        {
            throw new NotImplementedException();
        }


        public string[] Syntax
        {
            get { return new string[] { "MOVE address, Rx = Move address to Reg X" }; }
        }


        public string GetCommand()
        {
            throw new NotImplementedException();
        }
    }
}

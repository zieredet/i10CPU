using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Interfaces;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    public class MOVE : ICommand
    {

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
            throw new NotImplementedException();
        }
    }
}

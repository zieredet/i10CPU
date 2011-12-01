using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Impl.Commands
{
    /* 
     * For most of the Interface, I use a abstract Baseclass 
     * which implements default behavior and 
     * default values for most attributes and methods
     */
    public abstract class CommandBase 
    {
        public virtual int CommandLength { get { return 2; } }
        
        public abstract void Execute(IMemory mem, RegisterSet registerSet);

        public abstract string Name { get; }

        public abstract Instruction Decode(string opcode);

        public ICommand Parse(string codeline)
        {
            //if (String.IsNullOrEmpty(codeline)) continue;
            //else if (i1 == 0) continue;
            //else if (i1 > 0)
            //    opcode = codeline.Substring(0, i1 - 1).Trim();
            //else
            //    opcode = codeline.Trim();

            return null;
        }


    }
}

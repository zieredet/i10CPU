using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ch.zhaw.HenselerGroup.CPU.Interfaces;
using ch.zhaw.HenselerGroup.CPU.Impl;
using ch.zhaw.HenselerGroup.CPU.Impl.Commands;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;


namespace ch.zhaw.HenselerGroup.CPU.Impl
{
    // we don't like Refelction 
    // that's why we use a factory
    public class CommandFactory
    {
        public static ICommand GetCommand(string codeLine)
        {
            if (codeLine.StartsWith("ADDD ")) return new ADD();
            if (codeLine.StartsWith("ADD ")) return new ADD();
            if (codeLine.StartsWith("LOAD ")) return new LOAD();
            //if (codeLine.StartsWith("SLA ")) return new SLA();

            return null;
        }

        public static ICommand GetCommand(IWord codeLine)
        {
            if(ADD.CheckOpCode(codeLine)) return new ADD(); 

            return null;
        }
    }
}

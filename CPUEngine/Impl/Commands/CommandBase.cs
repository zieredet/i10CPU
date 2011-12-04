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

        public const int INVALID_VALUE_INT = int.MinValue;

        public abstract void Execute(IMemory mem, RegisterSet registerSet);

        public abstract string Name { get; }

        public abstract Instruction Decode(string opcode);

       

        /// <summary>
        /// Parse the number part 
        /// </summary>
        /// <param name="number"></param>
        /// <param name="part">which part of the command contains the number<br/>
        /// Sample: Add R1,500 => 3th part<br/>
        ///  ADD 500 => 2nd part</param>
        /// <returns></returns>
        public static int ParseNumber(string codeline, int part)
        {
            string[] ss = codeline.Split(' ', ',');
            if (ss.Length < part) return INVALID_VALUE_INT;   //  throw new IndexOutOfRangeException("Part does not exist");

            int nbr = INVALID_VALUE_INT;
            int.TryParse(ss[part - 1], out nbr);
            
            if (nbr < 0) nbr = Math.Abs(nbr) * 2 + 1;
            else nbr *= 2;
            return nbr;
        }

        public static int ParseRegister(string codeline, int part)
        {
            string[] ss = codeline.Split(' ', ',');
            if (ss.Length < part) return INVALID_VALUE_INT;   //  throw new IndexOutOfRangeException("Part does not exist");

            string s = ss[part - 1].ToUpper();
            if (!s.StartsWith("R")) return INVALID_VALUE_INT;

            int reg = INVALID_VALUE_INT;
            int.TryParse(s.Substring(1), out reg);
            return reg;
        }
    }
}

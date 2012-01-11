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
     * 
     * In this Case, we do not use an abstract class 
     * (since this is suposed to be a better style).
     * 
     * This class is a place for static methods 
     * used in Command-Classes since parsing, 
     * splitting, converting, etc.
     * 
     */
    public class CommandBase
    {

        public const int INVALID_VALUE_INT = int.MinValue;

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

        /// <summary>
        /// Parse the input an extract the Register Number.
        /// Sample: 
        ///   ParseRegister("Add R1,500", 2) => 1
        /// </summary>
        /// <returns>RestierNumber</br>
        /// in case of error it returns INVALID_VALUE_INT</returns>
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

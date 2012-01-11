using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    /// <summary>
    /// CPU Interface
    /// </summary>
    public interface ICPU
    {
        /// <summary>
        /// reads the pgm from filesystem and returns the pgm as an arrasy of strings.
        /// There could be filters for remarks or unsupported commands, etc. in it.
        /// 
        /// Use LoadMemory(..) to put the commands into the memory.
        /// </summary>
        /// <param name="fullFilename">FQFN</param>
        string[] ReadPgm(string fullFilename);

        /// <summary>
        /// Loads the given Pgm (as an string array) into the memory at the given address.
        /// </summary>
        void LoadMemory(string[] codelines, int startAddress);

        /// <summary>
        /// Run pgm. Start at address
        /// </summary>
        /// <param name="startAddress"></param>
        void Run(int startAddress);

        /// <summary>
        /// Run Pgm in Stepmode. Start at address
        /// </summary>
        /// <param name="startAddress"></param>
        void RunStep(int startAddress);

        /// <summary>
        /// Run pgm in Fastmode. Start at address.
        /// it's a kind of stepmode but without waiting 
        /// for user action
        /// </summary>
        /// <param name="startAddress"></param>
        void RunFast(int startAddress);

        /// <summary>
        /// getter for the Memory
        /// </summary>
        IMemory Memory { get; }

        /// <summary>
        /// returns the signed value of the given register
        /// </summary>
        int GetRegisterValue(int registerNr);

        /// <summary>
        /// returns the unsigned value of the given register.
        /// This is the real value stored in the register.
        /// </summary>
        int GetRegisterUValue(int registerNr);
    }
}

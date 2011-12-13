using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    public interface ICommand
    {       

        /// <summary>
        /// Executes the command, Writes direct to the memory
        /// </summary>
        void Execute(IMemory mem, RegisterSet registerSet);

        /// <summary>
        /// returns the name of the command e.g. "ADD", "MUL", ...
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Decodes a Mnemonic to a Instruction (Binary-Value)
        /// </summary>
        /// <param name="opcode">Sourcecode line from textfile. 
        /// Mostly Mnemonic</param>
        Instruction Decode();

        /// <summary>
        /// Length of the command in Bytes
        /// </summary>
        int CommandLength { get; }

        /// <summary>
        /// Parses a String to OpCode (Mnemonic)
        /// </summary>
        /// <param name="opcode"></param>
        void Parse(string opcode);

        string GetCommand();

        string[] Syntax { get; }
    }
}

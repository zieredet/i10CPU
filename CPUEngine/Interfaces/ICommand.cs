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
        /// Executes the command, writes direct to the memory and registerset
        /// </summary>
        void Execute(IMemory mem, RegisterSet registerSet);

        /// <summary>
        /// returns the name of the command e.g. "ADD", "MUL", ...
        /// </summary>
        String Name { get; }

        /// <summary>
        /// Decodes a Mnemonic command to a Instruction (Binary-Value)
        /// </summary>
        /// <param name="opcode">Sourcecode line from textfile. 
        /// Mostly Mnemonic</param>
        Instruction Decode();

        /// <summary>
        /// Length of the command in Bytes. Usualy 2 bytes
        /// </summary>
        int CommandLength { get; }

        /// <summary>
        /// Parses a String to OpCode (Mnemonic)
        /// </summary>
        void Parse(string opcode);

        /// <summary>
        /// returns the the command as a string in mnemonic style
        /// </summary>
        string GetCommand();

        /// <summary>
        /// Provides a string[] with syntax and help information.
        /// It will not be parsable. It's to display provided wrong syntax is used.
        /// </summary>
        string[] Syntax { get; }
    }
}

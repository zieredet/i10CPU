using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ch.zhaw.HenselerGroup.CPU.Impl.Memory;
using System.Collections;

namespace ch.zhaw.HenselerGroup.CPU.Interfaces
{
    /// <summary>
    /// Memory.
    /// To create a Memory for storing values do the following
    /// IMemory mem= new ...();
    /// mem.Init(size in bytes)
    /// </summary>
    public interface IMemory : IEnumerable<Word>
    {
        /// <summary>
        /// Sets and Init the memory
        /// </summary>
        /// <param name="size"></param>
        void Init(int size);

        /// <summary>
        /// Get the word at the address 
        /// </summary>
        /// <returns>a word not a byte. How long this word is, depends on the implementation</returns>
        Word GetWord(int address);
        
        void SetWord(int address, Word word);

        /// <summary>
        /// stores an insturction as a bytecode at the address. 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="instuction">bytecode of the instruction</param>
        void SetInstruction(int address, int instuction);

        /// <summary>
        /// stores an insturction at the address. 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="instruction">Instruction class</param>
        void SetInstruction(int address, Instruction instruction);

        /// <summary>
        /// Enumerator for the memory. You get only words.
        /// </summary>
        /// <returns></returns>
        // IEnumerator<Word> GetEnumerator();


    }
}
